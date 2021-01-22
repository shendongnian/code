    using Microsoft.Win32;
        
    static void Main(string[] args)
    {
            var Aliases = Registry.LocalMachine.OpenSubKey(
			    @"SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo");
            Aliases.GetValue("Alias");
    }
