    using System;
    using System.Runtime.InteropServices;
    using System.Collections;
    using System.Net;
    namespace dhcp
    {
    // c# class for processed clients
    public class dhcpClient
    {
        public string hostname { get; set; }
        public string ip       { get; set; }
        public string mac      { get; set; }
    }
    // structs for use with call to unmanaged code
    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_CLIENT_INFO_ARRAY
    {
        public uint NumElements;
        public IntPtr Clients;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct DHCP_CLIENT_UID
    {
        public uint DataLength;
        public IntPtr Data;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DHCP_CLIENT_INFO
    {
        public uint ip;
        public uint subnet;
        public DHCP_CLIENT_UID mac;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ClientName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ClientComment;
    }
    // main
    class Program
    {
        static void Main()
        {
            try
            {
                // get settings
                String server, subnet;
                Console.Write("Enter server : ");
                server = Console.ReadLine();
                Console.Write("Enter subnet : ");
                subnet = Console.ReadLine();
                // gather clients
                ArrayList clients = findDhcpClients(server, subnet);
                // output results
                Console.WriteLine();
                foreach (dhcpClient d in clients)
                    Console.WriteLine(String.Format("{0,-35} {1,-15} {2,-15}", d.hostname, d.ip, d.mac));
                Console.WriteLine('\n' + clients.Count.ToString() + " lease(s) in total");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
        static ArrayList findDhcpClients(string server, string subnet)
        {
            // set up container for processed clients
            ArrayList foundClients = new ArrayList();
            // make call to unmanaged code
            uint parsedMask     = StringIPAddressToUInt32(subnet);
            uint resumeHandle   = 0;
            uint numClientsRead = 0;
            uint totalClients   = 0;
            IntPtr info_array_ptr;
            uint response = DhcpEnumSubnetClients(
                server,
                parsedMask,
                ref resumeHandle,
                65536,
                out info_array_ptr,
                ref numClientsRead,
                ref totalClients
                );
            // set up client array casted to a DHCP_CLIENT_INFO_ARRAY
            // using the pointer from the response object above
            DHCP_CLIENT_INFO_ARRAY rawClients =
                (DHCP_CLIENT_INFO_ARRAY)Marshal.PtrToStructure(info_array_ptr, typeof(DHCP_CLIENT_INFO_ARRAY));
            // loop through the clients structure inside rawClients 
            // adding to the dchpClient collection
            IntPtr current = rawClients.Clients;
            for (int i = 0; i < (int)rawClients.NumElements; i++)
            {
                // 1. Create machine object using the struct
                DHCP_CLIENT_INFO rawMachine =
                    (DHCP_CLIENT_INFO)Marshal.PtrToStructure(Marshal.ReadIntPtr(current), typeof(DHCP_CLIENT_INFO));
                // 2. create new C# dhcpClient object and add to the 
                // collection (for hassle-free use elsewhere!!)
                dhcpClient thisClient = new dhcpClient();
                thisClient.ip = UInt32IPAddressToString(rawMachine.ip);
                thisClient.hostname = rawMachine.ClientName;
                thisClient.mac = String.Format("{0:x2}{1:x2}.{2:x2}{3:x2}.{4:x2}{5:x2}",
                    Marshal.ReadByte(rawMachine.mac.Data),
                    Marshal.ReadByte(rawMachine.mac.Data, 1),
                    Marshal.ReadByte(rawMachine.mac.Data, 2),
                    Marshal.ReadByte(rawMachine.mac.Data, 3),
                    Marshal.ReadByte(rawMachine.mac.Data, 4),
                    Marshal.ReadByte(rawMachine.mac.Data, 5));
                foundClients.Add(thisClient);
                // 3. move pointer to next machine
                current = (IntPtr)((int)current + (int)Marshal.SizeOf(typeof(IntPtr)));
            }
            return foundClients;
        }
        public static uint StringIPAddressToUInt32(string ip)
        {
            // convert string IP to uint IP e.g. "1.2.3.4" -> 16909060
            IPAddress i = System.Net.IPAddress.Parse(ip);
            byte[] ipByteArray = i.GetAddressBytes();
            uint ipUint = (uint)ipByteArray[0] << 24;
            ipUint += (uint)ipByteArray[1] << 16;
            ipUint += (uint)ipByteArray[2] << 8;
            ipUint += (uint)ipByteArray[3];
            return ipUint;
        }
        public static string UInt32IPAddressToString(uint ip)
        {
            // convert uint IP to string IP e.g. 16909060 -> "1.2.3.4"
            IPAddress i = new IPAddress(ip);
            string[] ipArray = i.ToString().Split('.');
            return ipArray[3] + "." + ipArray[2] + "." + ipArray[1] + "." + ipArray[0];
        }
        [DllImport("dhcpsapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint DhcpEnumSubnetClients(
                string ServerIpAddress,
                uint SubnetAddress,
            ref uint ResumeHandle,
                uint PreferredMaximum,
            out IntPtr ClientInfo,
            ref uint ElementsRead,
            ref uint ElementsTotal
        );
    }
    }
