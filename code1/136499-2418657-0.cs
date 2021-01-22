    public class Program {
        public void Main(string[] args) {
    		IntPtr pSessionInfo;
    		IntPtr pResumeHandle = IntPtr.Zero;
    		UInt32 entriesRead, totalEntries;
    		
    		var netStatus = NativeMethods.NetSessionEnum(
    			null, // local computer
    			null, // client name
    			null, // username
    			502, // include all info
    			out pSessionInfo, // pointer to SESSION_INFO_502[]
    			NativeMethods.MAX_PREFERRED_LENGTH,
    			out entriesRead,
    			out totalEntries,
    			ref pResumeHandle
    		);
    		
    		try {
    			if (netStatus != NativeMethods.NET_API_STATUS.NERR_Success) {
    				throw new InvalidOperationException(netStatus.ToString());
    			}
    			Console.WriteLine("Read {0} of {1} entries", entriesRead, totalEntries);
    			for (int i = 0; i < entriesRead; i++) {
    				var pCurrentSessionInfo = new IntPtr(pSessionInfo.ToInt32() + (NativeMethods.SESSION_INFO_502.SIZE_OF * i));
    				var s = (NativeMethods.SESSION_INFO_502)Marshal.PtrToStructure(pCurrentSessionInfo, typeof(NativeMethods.SESSION_INFO_502));
    				Console.WriteLine(
    					"User: {0}, Computer: {1}, Type: {2}, # Open Files: {3}, Connected Time: {4}s, Idle Time: {5}s, Guest: {6}",
    					s.sesi502_username,
    					s.sesi502_cname,
    					s.sesi502_cltype_name,
    					s.sesi502_num_opens,
    					s.sesi502_time,
    					s.sesi502_idle_time,
    					s.sesi502_user_flags == NativeMethods.SESSION_INFO_502_USER_FLAGS.SESS_GUEST
    				);
    			}
    		} finally {
    			NativeMethods.NetApiBufferFree(pSessionInfo);
    		}
        }
    }
    public sealed class NativeMethods {
    	[DllImport("netapi32.dll", SetLastError=true)]
        public static extern NET_API_STATUS NetSessionEnum(
                string serverName,
                string uncClientName,
                string userName,
                UInt32 level,
                out IntPtr bufPtr,
                int prefMaxLen,
                out UInt32 entriesRead,
                out UInt32 totalEntries,
                ref IntPtr resume_handle
    	);
    	
    	[DllImport("netapi32.dll")]
    	public static extern uint NetApiBufferFree(IntPtr Buffer);
    	
    	public const int MAX_PREFERRED_LENGTH = -1;
    	
    	public enum NET_API_STATUS : uint {
    		NERR_Success = 0,
    		NERR_InvalidComputer = 2351,
    		NERR_NotPrimary = 2226,
    		NERR_SpeGroupOp = 2234,
    		NERR_LastAdmin = 2452,
    		NERR_BadPassword = 2203,
    		NERR_PasswordTooShort = 2245,
    		NERR_UserNotFound = 2221,
    		ERROR_ACCESS_DENIED = 5,
    		ERROR_NOT_ENOUGH_MEMORY = 8,
    		ERROR_INVALID_PARAMETER = 87,
    		ERROR_INVALID_NAME = 123,
    		ERROR_INVALID_LEVEL = 124,
    		ERROR_MORE_DATA = 234 ,
    		ERROR_SESSION_CREDENTIAL_CONFLICT = 1219
    	}
    	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    	public struct SESSION_INFO_502 {
    		public static readonly int SIZE_OF = Marshal.SizeOf(typeof(SESSION_INFO_502));
            public string sesi502_cname;
            public string sesi502_username;
            public uint sesi502_num_opens;
            public uint sesi502_time;
            public uint sesi502_idle_time;
            public SESSION_INFO_502_USER_FLAGS sesi502_user_flags;
            public string sesi502_cltype_name;
            public string sesi502_transport;
        }
    	
    	public enum SESSION_INFO_502_USER_FLAGS : uint {
    		SESS_GUEST = 1,
    		SESS_NOENCRYPTION = 2
    	}
    }
