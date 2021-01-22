    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    
    namespace TcpMonitor
    {
    	/*
    		Usage:
    				var cons = TcpHelper.GetAllTCPConnections();
    				foreach (TcpHelper.MIB_TCPROW_OWNER_PID c in cons) ...
    	*/
    
    	public class NetHelper
    	{
    		[DllImport("iphlpapi.dll", SetLastError = true)]
    		static extern uint GetExtendedUdpTable(IntPtr pUdpTable, ref int dwOutBufLen, bool sort, int ipVersion, UDP_TABLE_CLASS tblClass, uint reserved = 0);
    
    		public enum UDP_TABLE_CLASS
    		{
    			UDP_TABLE_BASIC,
    			UDP_TABLE_OWNER_PID,
    			UDP_TABLE_OWNER_MODULE
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_UDPTABLE_OWNER_PID
    		{
    			public uint dwNumEntries;
    			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
    			public MIB_UDPROW_OWNER_PID[] table;
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_UDPROW_OWNER_PID
    		{
    			public uint localAddr;
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    			public byte[] localPort;
    			public uint owningPid;
    
    			public uint ProcessId
    			{
    				get { return owningPid; }
    			}
    
    			public IPAddress LocalAddress
    			{
    				get { return new IPAddress(localAddr); }
    			}
    
    			public ushort LocalPort
    			{
    				get { return BitConverter.ToUInt16(localPort.Take(2).Reverse().ToArray(), 0); }
    			}
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_UDP6TABLE_OWNER_PID
    		{
    			public uint dwNumEntries;
    			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
    			public MIB_UDP6ROW_OWNER_PID[] table;
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_UDP6ROW_OWNER_PID
    		{
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    			public byte[] localAddr;
    			public uint localScopeId;
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    			public byte[] localPort;
    			public uint owningPid;
    			public uint ProcessId
    			{
    				get { return owningPid; }
    			}
    
    			public IPAddress LocalAddress
    			{
    				get { return new IPAddress(localAddr, localScopeId); }
    			}
    
    			public ushort LocalPort
    			{
    				get { return BitConverter.ToUInt16(localPort.Take(2).Reverse().ToArray(), 0); }
    			}
    		}
    
    		public static List<MIB_UDPROW_OWNER_PID> GetAllUDPConnections()
    		{
    			return GetUDPConnections<MIB_UDPROW_OWNER_PID, MIB_UDPTABLE_OWNER_PID> (AF_INET);
    		}
    
    		public static List<MIB_UDP6ROW_OWNER_PID> GetAllUDPv6Connections()
    		{
    			return GetUDPConnections<MIB_UDP6ROW_OWNER_PID, MIB_UDP6TABLE_OWNER_PID>(AF_INET6);
    		}
    		
    		private static List<IPR> GetUDPConnections<IPR, IPT>(int ipVersion)//IPR = Row Type, IPT = Table Type
    		{
    			List<IPR> result = null;
    
    			IPR[] tableRows = null;
    			int buffSize = 0;
    
    			var dwNumEntriesField = typeof(IPT).GetField("dwNumEntries");
    
    			// how much memory do we need?
    			uint ret = GetExtendedUdpTable(IntPtr.Zero, ref buffSize, true, ipVersion, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID);
    			IntPtr udpTablePtr = Marshal.AllocHGlobal(buffSize);
    
    			try
    			{
    				ret = GetExtendedUdpTable(udpTablePtr, ref buffSize, true, ipVersion, UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID);
    				if (ret != 0)
    					return new List<IPR>();
    
    				// get the number of entries in the table
    				IPT table = (IPT)Marshal.PtrToStructure(udpTablePtr, typeof(IPT));
    				int rowStructSize = Marshal.SizeOf(typeof(IPR));
    				uint numEntries = (uint)dwNumEntriesField.GetValue(table);
    
    				// buffer we will be returning
    				tableRows = new IPR[numEntries];
    
    				IntPtr rowPtr = (IntPtr)((long)udpTablePtr + 4);
    				for (int i = 0; i < numEntries; i++)
    				{
    					IPR tcpRow = (IPR)Marshal.PtrToStructure(rowPtr, typeof(IPR));
    					tableRows[i] = tcpRow;
    					rowPtr = (IntPtr)((long)rowPtr + rowStructSize);   // next entry
    				}
    			}
    			finally
    			{
    				result = tableRows?.ToList() ?? new List<IPR>();
    
    				// Free the Memory
    				Marshal.FreeHGlobal(udpTablePtr);
    			}
    
    			return result;
    		}
    		
    		[DllImport("iphlpapi.dll", SetLastError = true)]
    		static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TCP_TABLE_CLASS tblClass, uint reserved = 0);
    
    
    
    		public enum MIB_TCP_STATE
    		{
    			MIB_TCP_STATE_CLOSED = 1,
    			MIB_TCP_STATE_LISTEN = 2,
    			MIB_TCP_STATE_SYN_SENT = 3,
    			MIB_TCP_STATE_SYN_RCVD = 4,
    			MIB_TCP_STATE_ESTAB = 5,
    			MIB_TCP_STATE_FIN_WAIT1 = 6,
    			MIB_TCP_STATE_FIN_WAIT2 = 7,
    			MIB_TCP_STATE_CLOSE_WAIT = 8,
    			MIB_TCP_STATE_CLOSING = 9,
    			MIB_TCP_STATE_LAST_ACK = 10,
    			MIB_TCP_STATE_TIME_WAIT = 11,
    			MIB_TCP_STATE_DELETE_TCB = 12
    		}
    
    		public enum TCP_TABLE_CLASS
    		{
    			TCP_TABLE_BASIC_LISTENER,
    			TCP_TABLE_BASIC_CONNECTIONS,
    			TCP_TABLE_BASIC_ALL,
    			TCP_TABLE_OWNER_PID_LISTENER,
    			TCP_TABLE_OWNER_PID_CONNECTIONS,
    			TCP_TABLE_OWNER_PID_ALL,
    			TCP_TABLE_OWNER_MODULE_LISTENER,
    			TCP_TABLE_OWNER_MODULE_CONNECTIONS,
    			TCP_TABLE_OWNER_MODULE_ALL
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_TCPTABLE_OWNER_PID
    		{
    			public uint dwNumEntries;
    			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
    			public MIB_TCPROW_OWNER_PID[] table;
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_TCP6TABLE_OWNER_PID
    		{
    			public uint dwNumEntries;
    			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
    			public MIB_TCP6ROW_OWNER_PID[] table;
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_TCPROW_OWNER_PID
    		{
    			public uint state;
    			public uint localAddr;
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    			public byte[] localPort;
    			public uint remoteAddr;
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    			public byte[] remotePort;
    			public uint owningPid;
    
    			public uint ProcessId
    			{
    				get { return owningPid; }
    			}
    
    			public IPAddress LocalAddress
    			{
    				get { return new IPAddress(localAddr); }
    			}
    
    			public ushort LocalPort
    			{
    				get
    				{
    					return BitConverter.ToUInt16(new byte[2] { localPort[1], localPort[0] }, 0);
    				}
    			}
    
    			public IPAddress RemoteAddress
    			{
    				get { return new IPAddress(remoteAddr); }
    			}
    
    			public ushort RemotePort
    			{
    				get
    				{
    					return BitConverter.ToUInt16(new byte[2] { remotePort[1], remotePort[0] }, 0);
    				}
    			}
    
    			public MIB_TCP_STATE State
    			{
    				get { return (MIB_TCP_STATE)state; }
    			}
    		}
    
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct MIB_TCP6ROW_OWNER_PID
    		{
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    			public byte[] localAddr;
    			public uint localScopeId;
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    			public byte[] localPort;
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    			public byte[] remoteAddr;
    			public uint remoteScopeId;
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    			public byte[] remotePort;
    			public uint state;
    			public uint owningPid;
    
    			public uint ProcessId
    			{
    				get { return owningPid; }
    			}
    
    			public long LocalScopeId
    			{
    				get { return localScopeId; }
    			}
    
    			public IPAddress LocalAddress
    			{
    				get { return new IPAddress(localAddr, LocalScopeId); }
    			}
    
    			public ushort LocalPort
    			{
    				get { return BitConverter.ToUInt16(localPort.Take(2).Reverse().ToArray(), 0); }
    			}
    
    			public long RemoteScopeId
    			{
    				get { return remoteScopeId; }
    			}
    
    			public IPAddress RemoteAddress
    			{
    				get { return new IPAddress(remoteAddr, RemoteScopeId); }
    			}
    
    			public ushort RemotePort
    			{
    				get { return BitConverter.ToUInt16(remotePort.Take(2).Reverse().ToArray(), 0); }
    			}
    
    			public MIB_TCP_STATE State
    			{
    				get { return (MIB_TCP_STATE)state; }
    			}
    		}
    
    
    		public const int AF_INET = 2;    // IP_v4 = System.Net.Sockets.AddressFamily.InterNetwork
    		public const int AF_INET6 = 23;  // IP_v6 = System.Net.Sockets.AddressFamily.InterNetworkV6
    
    		public static Task<List<MIB_TCPROW_OWNER_PID>> GetAllTCPConnectionsAsync()
    		{
    			return Task.Run(() => GetTCPConnections<MIB_TCPROW_OWNER_PID, MIB_TCPTABLE_OWNER_PID>(AF_INET));
    		}
    
    		public static List<MIB_TCPROW_OWNER_PID> GetAllTCPConnections()
    		{
    			return GetTCPConnections<MIB_TCPROW_OWNER_PID, MIB_TCPTABLE_OWNER_PID>(AF_INET);
    		}
    
    		public static Task<List<MIB_TCP6ROW_OWNER_PID>> GetAllTCPv6ConnectionsAsync()
    		{
    			return Task.Run(()=>GetTCPConnections<MIB_TCP6ROW_OWNER_PID, MIB_TCP6TABLE_OWNER_PID>(AF_INET6));
    		}
    
    		public static List<MIB_TCP6ROW_OWNER_PID> GetAllTCPv6Connections()
    		{
    			return GetTCPConnections<MIB_TCP6ROW_OWNER_PID, MIB_TCP6TABLE_OWNER_PID>(AF_INET6);
    		}
    
    		private static List<IPR> GetTCPConnections<IPR, IPT>(int ipVersion)//IPR = Row Type, IPT = Table Type
    		{
    			List<IPR> result = null;
    
    			IPR[] tableRows = null;
    			int buffSize = 0;
    
    			var dwNumEntriesField = typeof(IPT).GetField("dwNumEntries");
    
    			// how much memory do we need?
    			uint ret = GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
    			IntPtr tcpTablePtr = Marshal.AllocHGlobal(buffSize);
    
    			try
    			{
    				ret = GetExtendedTcpTable(tcpTablePtr, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
    				if (ret != 0)
    					return new List<IPR>();
    
    				// get the number of entries in the table
    				IPT table = (IPT)Marshal.PtrToStructure(tcpTablePtr, typeof(IPT));
    				int rowStructSize = Marshal.SizeOf(typeof(IPR));
    				uint numEntries = (uint)dwNumEntriesField.GetValue(table);
    
    				// buffer we will be returning
    				tableRows = new IPR[numEntries];
    
    				IntPtr rowPtr = (IntPtr)((long)tcpTablePtr + 4);
    				for (int i = 0; i < numEntries; i++)
    				{
    					IPR tcpRow = (IPR)Marshal.PtrToStructure(rowPtr, typeof(IPR));
    					tableRows[i] = tcpRow;
    					rowPtr = (IntPtr)((long)rowPtr + rowStructSize);   // next entry
    				}
    			}
    			finally
    			{
    				result = tableRows?.ToList() ?? new List<IPR>();
    
    				// Free the Memory
    				Marshal.FreeHGlobal(tcpTablePtr);
    			}
    
    			return result;
    		}
    
    		public static string GetTcpStateName(MIB_TCP_STATE state)
    		{
    			switch (state)
    			{
    				case MIB_TCP_STATE.MIB_TCP_STATE_CLOSED:
    					return "Closed";
    				case MIB_TCP_STATE.MIB_TCP_STATE_LISTEN:
    					return "Listen";
    				case MIB_TCP_STATE.MIB_TCP_STATE_SYN_SENT:
    					return "SynSent";
    				case MIB_TCP_STATE.MIB_TCP_STATE_SYN_RCVD:
    					return "SynReceived";
    				case MIB_TCP_STATE.MIB_TCP_STATE_ESTAB:
    					return "Established";
    				case MIB_TCP_STATE.MIB_TCP_STATE_FIN_WAIT1:
    					return "FinWait 1";
    				case MIB_TCP_STATE.MIB_TCP_STATE_FIN_WAIT2:
    					return "FinWait 2";
    				case MIB_TCP_STATE.MIB_TCP_STATE_CLOSE_WAIT:
    					return "CloseWait";
    				case MIB_TCP_STATE.MIB_TCP_STATE_CLOSING:
    					return "Closing";
    				case MIB_TCP_STATE.MIB_TCP_STATE_LAST_ACK:
    					return "LastAck";
    				case MIB_TCP_STATE.MIB_TCP_STATE_TIME_WAIT:
    					return "TimeWait";
    				case MIB_TCP_STATE.MIB_TCP_STATE_DELETE_TCB:
    					return "DeleteTCB";
    				default:
    					return ((int)state).ToString();
    			}
    		}
    
    		private static readonly ConcurrentDictionary<string, string> DicOfIpToHostName = new ConcurrentDictionary<string, string>();
    
    		public const string UnknownHostName = "Unknown";
    
    		// ******************************************************************
    		public static string GetHostName(IPAddress ipAddress)
    		{
    			return GetHostName(ipAddress.ToString());
    		}
    
    		// ******************************************************************
    		public static string GetHostName(string ipAddress)
    		{
    			string hostName = null;
    
    			if (!DicOfIpToHostName.TryGetValue(ipAddress, out hostName))
    			{
    				try
    				{
    					if (ipAddress == "0.0.0.0" || ipAddress == "::")
    					{
    						hostName = ipAddress;
    					}
    					else
    					{
    						hostName = Dns.GetHostEntry(ipAddress).HostName;
    					}
    				}
    				catch (Exception ex)
    				{
    					Debug.Print(ex.ToString());
    					hostName = UnknownHostName;
    				}
    
    				DicOfIpToHostName[ipAddress] = hostName;
    			}
    
    			return hostName;
    		}
    
    		// ************************************************************************
    		/// <summary>
    		/// Will search for the an active NetworkInterafce that has a Gateway, otherwise
    		/// it will fallback to try from the DNS which is not safe.
    		/// </summary>
    		/// <returns></returns>
    		public static NetworkInterface GetMainNetworkInterface()
    		{
    			List<NetworkInterface> candidates = new List<NetworkInterface>();
    
    			if (NetworkInterface.GetIsNetworkAvailable())
    			{
    				NetworkInterface[] NetworkInterfaces =
    					NetworkInterface.GetAllNetworkInterfaces();
    
    				foreach (
    					NetworkInterface ni in NetworkInterfaces)
    				{
    					if (ni.OperationalStatus == OperationalStatus.Up)
    						candidates.Add(ni);
    				}
    			}
    
    			if (candidates.Count == 1)
    			{
    				return candidates[0];
    			}
    
    			// Accoring to our tech, the main NetworkInterface should have a Gateway 
    			// and it should be the ony one with a gateway.
    			if (candidates.Count > 1)
    			{
    				for (int n = candidates.Count - 1; n >= 0; n--)
    				{
    					if (candidates[n].GetIPProperties().GatewayAddresses.Count == 0)
    					{
    						candidates.RemoveAt(n);
    					}
    				}
    
    				if (candidates.Count == 1)
    				{
    					return candidates[0];
    				}
    			}
    
    			// Fallback to try by getting my ipAdress from the dns
    			IPAddress myMainIpAdress = null;
    			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
    			foreach (IPAddress ip in host.AddressList)
    			{
    				if (ip.AddressFamily == AddressFamily.InterNetwork) // Get the first IpV4
    				{
    					myMainIpAdress = ip;
    					break;
    				}
    			}
    
    			if (myMainIpAdress != null)
    			{
    				NetworkInterface[] NetworkInterfaces =
    					NetworkInterface.GetAllNetworkInterfaces();
    
    				foreach (NetworkInterface ni in NetworkInterfaces)
    				{
    					if (ni.OperationalStatus == OperationalStatus.Up)
    					{
    						IPInterfaceProperties props = ni.GetIPProperties();
    						foreach (UnicastIPAddressInformation ai in props.UnicastAddresses)
    						{
    							if (ai.Address.Equals(myMainIpAdress))
    							{
    								return ni;
    							}
    						}
    					}
    				}
    			}
    
    			return null;
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// AddressFamily.InterNetwork = IPv4
    		/// Thanks to Dr. Wilys Apprentice at
    		/// http://stackoverflow.com/questions/1069103/how-to-get-the-ip-address-of-the-server-on-which-my-c-sharp-application-is-runni
    		/// using System.Net.NetworkInformation;
    		/// </summary>
    		/// <param name="mac"></param>
    		/// <param name="addressFamily">AddressFamily.InterNetwork = IPv4,  AddressFamily.InterNetworkV6 = IPv6</param>
    		/// <returns></returns>
    		public static IPAddress GetIpFromMac(PhysicalAddress mac, AddressFamily addressFamily = AddressFamily.InterNetwork)
    		{
    			NetworkInterface[] NetworkInterfaces =
    				NetworkInterface.GetAllNetworkInterfaces();
    
    			foreach (NetworkInterface ni in NetworkInterfaces)
    			{
    				if (ni.GetPhysicalAddress().Equals(mac))
    				{
    					if (ni.OperationalStatus == OperationalStatus.Up)
    					{
    						IPInterfaceProperties props = ni.GetIPProperties();
    						foreach (UnicastIPAddressInformation ai in props.UnicastAddresses)
    						{
    							if (ai.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred)
    							{
    								if (ai.Address.AddressFamily == addressFamily)
    								{
    									return ai.Address;
    								}
    							}
    						}
    					}
    				}
    			}
    
    			return null;
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Return the best guess of main ipAdress. To get it in the form aaa.bbb.ccc.ddd just call 
    		/// '?.ToString() ?? ""' on the result.
    		/// </summary>
    		/// <returns></returns>
    		public static IPAddress GetMyInternetIpAddress()
    		{
    			NetworkInterface ni = GetMainNetworkInterface();
    			IPAddress ipAddress = GetIpFromMac(ni.GetPhysicalAddress());
    			if (ipAddress == null) // could it be possible ?
    			{
    				ipAddress = GetIpFromMac(ni.GetPhysicalAddress(), AddressFamily.InterNetworkV6);
    			}
    
    			return ipAddress;
    		}
    
    		// ******************************************************************
    		public static bool IsBroadcastAddress(IPAddress ipAddress)
    		{
    			if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
    			{
    				return ipAddress.GetAddressBytes()[3] == 255;
    			}
    
    			if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
    			{
    				return false; // NO broadcast in IPv6
    			}
    
    			return false;
    		}
    
    		// ******************************************************************
    		public static bool IsMulticastAddress(IPAddress ipAddress)
    		{
    			if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
    			{
    				// Source: https://technet.microsoft.com/en-us/library/cc772041(v=ws.10).aspx
    				return ipAddress.GetAddressBytes()[0] >= 224 && ipAddress.GetAddressBytes()[0] <= 239;
    			}
    
    			if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
    			{
    				return ipAddress.IsIPv6Multicast;
    			}
    
    			return false;
    		}
    
    		// ******************************************************************
    
    	}
    }
