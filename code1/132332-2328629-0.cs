    public class WMIInstance
    {
        private readonly string CreatedWmiNamespace = "root\\microsoftdns";
        private readonly string CreatedClassName = "MicrosoftDNS_AAAAType";
        private readonly System.Management.ManagementScope statMgmtScope = null;
        public WMIInstance( string namespace, string className, ManagementScope scope )
        { /*... initialize private members here... */
        public WMI.ManagementTypeCollection GetInstances( System.String[] selectedProperties )
        { return WMI.Object.GetInstances( ... ); }
        /* other overloads ... */
    }
    public class AAAAType : WMI.Object
    {
        private static string CreatedWmiNamespace = "root\\microsoftdns";
        private static string CreatedClassName = "MicrosoftDNS_AAAAType";
        private static System.Management.ManagementScope statMgmtScope = null;
        private static readonly WMIInstances _instances = new WMIInstance( CreatedWmiNamespace, CreatedClassName, statMgmgtScope );
        public static WMIInstances Getter { get { return _instances; } }
    }
