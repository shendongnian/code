		public static async Task<IPHostEntry> GetHostEntryAsync(string host, string dns = null)
		{
			if (string.IsNullOrEmpty(host))
			{
				return null;
			}
			//Check if any cached result exists
			Tuple<string, string> key = new Tuple<string, string>(host, dns);
			if (NetHelper._dnsCache.TryGetValue(key, out Tuple<IPHostEntry, DateTime> record) && record.Item2 > DateTime.Now)
			{
				return record.Item1;
			}
			//Check dns server's address or port
			IPHostEntry result = null;
			int dnsPort;
			if (dns != null)
			{
				string[] blocks = dns.Split(':');
				if (blocks.Length == 2 && int.TryParse(blocks[1], out dnsPort))//dns is ip v4
				{
					dns = blocks[0];
				}
				else if (blocks.Length == 9 && int.TryParse(blocks[8], out dnsPort))//dns is ip v6
				{
					blocks[0] = blocks[0].TrimStart('[');
					blocks[7] = blocks[7].TrimStart(']');
					dns = string.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}", blocks);
				}
				else
				{
					dnsPort = 53;
				}
			}
			else
			{
				dnsPort = 53;
			}
			//Check if host is ip address
			if (host[0] == '[' && host[host.Length - 1] == ']')//IPV6 address
			{
				host = host.Substring(1, host.Length - 2);
			}
			if (IPAddress.TryParse(host, out IPAddress address))
			{
				result = new IPHostEntry { AddressList = new IPAddress[] { address } };
			}
			else if (string.IsNullOrEmpty(dns))
			{
				result = await Dns.GetHostEntryAsync(host);
			}
			else
			{
				#region Resolve with customized dns server
				IPAddress dnsAddr;
				if (!IPAddress.TryParse(dns, out dnsAddr))
				{
					throw new ArgumentException("The dns host must be ip address.", nameof(dns));
				}
				using (MemoryStream ms = new MemoryStream())
				{
					Random rnd = new Random();
					//About the dns message:http://www.ietf.org/rfc/rfc1035.txt
					//Write message header.
					ms.Write(new byte[] {
						(byte)rnd.Next(0, 0xFF),(byte)rnd.Next(0, 0xFF),
						0x01,
						0x00,
						0x00,0x01,
						0x00,0x00,
						0x00,0x00,
						0x00,0x00
					}, 0, 12);
					//Write the host to query.
					foreach (string block in host.Split('.'))
					{
						byte[] data = Encoding.UTF8.GetBytes(block);
						ms.WriteByte((byte)data.Length);
						ms.Write(data, 0, data.Length);
					}
					ms.WriteByte(0);//The end of query, muest 0(null string)
					//Query type:A
					ms.WriteByte(0x00);
					ms.WriteByte(0x01);
					//Query class:IN
					ms.WriteByte(0x00);
					ms.WriteByte(0x01);
					Socket socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
					try
					{
						//send to dns server
						byte[] buffer = ms.ToArray();
						while (socket.SendTo(buffer, 0, buffer.Length, SocketFlags.None, new IPEndPoint(dnsAddr, dnsPort)) < buffer.Length) ;
						buffer = new byte[0x100];
						EndPoint ep = socket.LocalEndPoint;
						int num = socket.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ep);
						//The response message has the same header and question structure, so we move index to the answer part directly.
						int index = (int)ms.Length;
						//Parse response records.
						void SkipName()
						{
							while (index < num)
							{
								int length = buffer[index++];
								if (length == 0)
								{
									break;
								}
								else if (length > 191)
								{
									return;
								}
								index += length;
							}
						}
						List<IPAddress> addresses = new List<IPAddress>();
						while (index < num)
						{
							SkipName();//Seems the name of record is useless in this scense, so we just needs to get the next index after name.
							byte type = buffer[index += 2];
							index += 7;//Skip class and ttl
							int length = buffer[index++] << 8 | buffer[index++];//Get record data's length
							if (type == 0x01)//A record
							{
								if (length == 4)//Parse record data to ip v4, this is what we need.
								{
									addresses.Add(new IPAddress(new byte[] { buffer[index], buffer[index + 1], buffer[index + 2], buffer[index + 3] }));
								}
							}
							index += length;
						}
						result = new IPHostEntry { AddressList = addresses.ToArray() };
					}
					finally
					{
						socket.Dispose();
					}
				}
				#endregion
			}
			//Cache and return result
			NetHelper._dnsCache[key] = new Tuple<IPHostEntry, DateTime>(result, DateTime.Now.AddMinutes(15));
			#pragma warning disable CS4014
			Task.Run(async () =>
			{
				await Task.Delay((int)TimeSpan.FromMinutes(15).TotalMilliseconds);
				NetHelper._dnsCache.Remove(key);
			});
			#pragma warning restore CS4014
			return result;
		}
