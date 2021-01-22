	class WNetConnection : IDisposable
	{
		public readonly string RemoteShare;
		public WNetConnection( string remoteHost, string remoteUser, string remotePassword )
		{
			Uri loc;
			if( !Uri.TryCreate( remoteHost, UriKind.Absolute, out loc ) || loc.IsUnc == false )
				throw new ApplicationException( "Not a valid UNC path: " + remoteHost );
			string auth = loc.Host;
			string[] segments = loc.Segments;
			// expected format is '\\machine\share'
			this.RemoteShare = String.Format( @"\\{0}\{1}", auth, segments[1].Trim( '\\', '/' ) );
			this.Connect( remoteUser, remotePassword );
		}
		~WNetConnection()
		{
			Disconnect();
		}
		public void Dispose()
		{
			Disconnect();
			GC.SuppressFinalize( this );
		}
		#region Win32 API...
		[StructLayout( LayoutKind.Sequential )]
		internal struct NETRESOURCE
		{
			public int dwScope;
			public int dwType;
			public int dwDisplayType;
			public int dwUsage;
			[MarshalAs( UnmanagedType.LPWStr )]
			public string lpLocalName;
			[MarshalAs( UnmanagedType.LPWStr )]
			public string lpRemoteName;
			[MarshalAs( UnmanagedType.LPWStr )]
			public string lpComment;
			[MarshalAs( UnmanagedType.LPWStr )]
			public string lpProvider;
		}
		[DllImport( "mpr.dll", EntryPoint = "WNetAddConnection2W", CharSet = System.Runtime.InteropServices.CharSet.Unicode )]
		private static extern int WNetAddConnection2( ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, Int32 dwFlags );
		[DllImport( "mpr.dll", EntryPoint = "WNetCancelConnectionW", CharSet = System.Runtime.InteropServices.CharSet.Unicode )]
		private static extern int WNetCancelConnection( string lpRemoteName, bool bForce );
		private const int RESOURCETYPE_ANY = 0x00000000;
		private const int RESOURCETYPE_DISK = 0x00000001;
		private const int CONNECT_INTERACTIVE = 0x00000008;
		private const int CONNECT_PROMPT = 0x00000010;
		private const int NO_ERROR = 0;
		void Connect( string remoteUser, string remotePassword )
		{
			NETRESOURCE ConnInf = new NETRESOURCE();
			ConnInf.dwScope = 0;
			ConnInf.dwType = RESOURCETYPE_DISK;
			ConnInf.dwDisplayType = 0;
			ConnInf.dwUsage = 0;
			ConnInf.lpRemoteName = this.RemoteShare;
			ConnInf.lpLocalName = null;
			ConnInf.lpComment = null;
			ConnInf.lpProvider = null;
			// user must be qualified 'authority\user'
			if( remoteUser.IndexOf( '\\' ) < 0 )
				remoteUser = String.Format( @"{0}\{1}", new Uri(RemoteShare).Host, remoteUser );
			int dwResult = WNetAddConnection2( ref ConnInf, remotePassword, remoteUser, 0 );
			if( NO_ERROR != dwResult )
				throw new Win32Exception( dwResult );
		}
		void Disconnect()
		{
			int dwResult = WNetCancelConnection( this.RemoteShare, true );
			if( NO_ERROR != dwResult )
				throw new Win32Exception( dwResult );
		}
		#endregion
	}
