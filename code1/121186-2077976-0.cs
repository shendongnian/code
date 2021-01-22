    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    namespace EnumerateUsers
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ue = new UserEnumerator();
                foreach(string userName in ue.GetLoggedOnUsers(null))
                {
                    Console.WriteLine(userName);
                }
            }
            
        }
    
        class UserEnumerator
        {
            public IEnumerable<string> GetLoggedOnUsers(string host)
            {
                int entriesRead, totalEntries, resumeHandle = 0;
                IntPtr pBuffer = IntPtr.Zero;
                try
                {
                    int result = NetWkstaUserEnum(host, 0, out pBuffer, MAX_PREFERRED_LENGTH, out entriesRead, out totalEntries, ref resumeHandle);
                    if (result != NERR_Success)  
                        throw new ApplicationException(String.Format("Failed to enumerate users, error code {0}", result));
    
                    return GetUsersFromStruct(pBuffer, entriesRead).ToList();
                }
                finally
                {
                    if (pBuffer != IntPtr.Zero)
                        NetApiBufferFree(pBuffer);
                    }
    
            }
    
            private IEnumerable<string> GetUsersFromStruct(IntPtr pBuffer, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    var user = (WKSTA_USER_INFO_0)Marshal.PtrToStructure(pBuffer, typeof(WKSTA_USER_INFO_0));
                    yield return user.username;
                    pBuffer = IntPtr.Add(pBuffer, user.username.Length * 2);                
                }
            }
            [DllImport("netapi32.dll")]
            private static extern int NetWkstaUserEnum(string host, int level, out IntPtr pBuffer, int prefMaxLength, out int entriesRead,
                                         out int totalEntries, ref int resumeHandle);
    
            [DllImport("netapi32.dll")]
            private static extern int NetApiBufferFree(IntPtr buffer);
    
            private const int MAX_PREFERRED_LENGTH = -1;
    
            private const int NERR_Success = 0;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        struct WKSTA_USER_INFO_0
        { 
            [MarshalAs(UnmanagedType.LPTStr)]
            internal string username;
        }
    }
