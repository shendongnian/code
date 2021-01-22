    [ConfigurationProperty("ZDRFile", DefaultValue = "", IsRequired = true)]
    [TypeConverter(typeof(YourCustomFileInfoTypeConverter))]
    public FileInfo ZDRFile {
        get { return (FileInfo)this["ZDRFile"]; }
        set { this["ZDRFile"] = value; }
    }
