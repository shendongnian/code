    public virtual string ReadCoreVersion()
    {
        var ea = Assembly.GetExecutingAssembly();
        var an = new AssemblyName(ea.FullName);
        var v = an.Version;
        var versionBuilder = new StringBuilder();
        versionBuilder.Append(v.Major);
        versionBuilder.Append('.');
        versionBuilder.Append(v.Minor);
        versionBuilder.Append('.');
        versionBuilder.Append(v.Build);
        versionBuilder.Append('.');
        versionBuilder.Append(v.Revision);
        return versionBuilder.ToString();
    }
