    [WMIClass("Win32_UserAccount")]
    public class UserAccount
    {
        public string Name { get; set; }
        public bool Disabled { get; set; }
    }
