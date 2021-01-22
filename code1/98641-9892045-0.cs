    using System;
    using System.DirectoryServices;
    using System.Runtime.InteropServices;
    
    //This is the managed definition of this interface also found in
    ActiveDs.tlb
    [ComImport]
    [Guid("9068270B-0939-11D1-8BE1-00C04FD8D503")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface IADsLargeInteger
    {
        [DispId(0x00000002)]
        int HighPart{get; set;}
        [DispId(0x00000003)]
        int LowPart{get; set;}
    }
    
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            DirectoryEntry entry = new
    DirectoryEntry("LDAP://cn=user,cn=users,dc=domain,dc=com");
            if(entry.Properties.Contains("lastLogon"))
            {
                IADsLargeInteger li =
    (IADsLargeInteger)entry.Properties["lastLogon"][0];    
                long date = (long)li.HighPart << 32 | (uint)li.LowPart;
                DateTime time = DateTime.FromFileTime(date);
                Console.WriteLine("Last logged on at: {0}", time);
            }
        }
    
    }
