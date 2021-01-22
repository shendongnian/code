    public class RenameComputer
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern bool SetComputerNameEx(COMPUTER_NAME_FORMAT NameType, string lpBuffer);
        enum COMPUTER_NAME_FORMAT
        {
            ComputerNameNetBIOS,
            ComputerNameDnsHostname,
            ComputerNameDnsDomain,
            ComputerNameDnsFullyQualified,
            ComputerNamePhysicalNetBIOS,
            ComputerNamePhysicalDnsHostname,
            ComputerNamePhysicalDnsDomain,
            ComputerNamePhysicalDnsFullyQualified,
        }
        //ComputerNamePhysicalDnsHostname used to rename the computer name and netbios name before domain join
        public static bool Rename(string name)
        {
            bool result = SetComputerNameEx(COMPUTER_NAME_FORMAT.ComputerNamePhysicalDnsHostname, name);
            if (!result)
                throw new Win32Exception();
     
            return result;
        }
    }
