    var version = Assembly.GetExecutingAssembly().GetName().Version();
    Debug.Assert(version.Major >= 0 && version.Major < 100)
    Debug.Assert(version.Minor >= 0 && version.Minor < 100)
    Debug.Assert(version.Build >= 0 && version.Build < 10000)
    Debug.Assert(version.Revision >= 0 && version.Revision < 100)
    long longVersion = version.Major * 100000000L + 
                       version.Minor * 1000000L + 
                       version.Build * 100L + 
                       version.Revision;
    int intVersion  = (int) longVersion;
    Debug.Assert((long)intVersion == longVersion)
