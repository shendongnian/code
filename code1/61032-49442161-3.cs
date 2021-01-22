    var version = NetFrameworkUtilities.GetVersion();
    if (version != null && version < new Version(4, 5))
    {
        MessageBox.Show("Your .NET Framework version is less than 4.5");
    }
