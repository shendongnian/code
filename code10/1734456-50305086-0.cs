    public static string DecodeMessage(Byte[] bytes)
        {
            string incomingData = string.Empty;
            byte secondByte = bytes[1];
            int dataLength = secondByte & 127;
            int indexFirstMask = 2;
            if (dataLength == 126)
                indexFirstMask = 4;
            else if (dataLength == 127)
                indexFirstMask = 10;
            IEnumerable<byte> keys = bytes.Skip(indexFirstMask).Take(4);
            int indexFirstDataByte = indexFirstMask + 4;
            byte[] decoded = new byte[bytes.Length - indexFirstDataByte];
            for (int i = indexFirstDataByte, j = 0; i < bytes.Length; i++, j++)
            {
                decoded[j] = (byte)(bytes[i] ^ keys.ElementAt(j % 4));
            }
            return Encoding.UTF8.GetString(decoded, 0, decoded.Length);
        }
    public static void SendString(string userName ,string str)
        {
            if (!userConnections.ContainsKey(userName))
                return;
            TcpClient client = userConnections[userName];
            NetworkStream _stream = client.GetStream();
            try
            {
                var buf = Encoding.UTF8.GetBytes(str);
                int frameSize = 64;
                var parts = buf.Select((b, i) => new { b, i })
                                .GroupBy(x => x.i / (frameSize - 1))
                                .Select(x => x.Select(y => y.b).ToArray())
                                .ToList();
                for (int i = 0; i < parts.Count; i++)
                {
                    byte cmd = 0;
                    if (i == 0) cmd |= 1;
                    if (i == parts.Count - 1) cmd |= 0x80;
                    _stream.WriteByte(cmd);
                    _stream.WriteByte((byte)parts[i].Length);
                    _stream.Write(parts[i], 0, parts[i].Length);
                }
                _stream.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
