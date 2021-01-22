static void EnumServices(string host, string username, string password)
{
    string ns = @"root\cimv2";
    string query = "select * from Win32_Service";
    ConnectionOptions options = new ConnectionOptions();
    if (!string.IsNullOrEmpty(username))
    {
        options.Username = username;
        options.Password = password;
    }
    ManagementScope scope = 
        new ManagementScope(string.Format(@"\\{0}\{1}", host, ns), options);
    scope.Connect();
    ManagementObjectSearcher searcher = 
        new ManagementObjectSearcher(scope, new ObjectQuery(query));
    ManagementObjectCollection retObjectCollection = searcher.Get();
    foreach (ManagementObject mo in searcher.Get())
    {
        Console.WriteLine(mo.GetText(TextFormat.Mof));
    }
}
