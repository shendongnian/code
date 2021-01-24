    public class EFCoreContext: DbContext
    {
            private string ConnectionString { get; set; }
            public EFCoreContext() : base()
            { 
                var settingsPath= AppDomain.CurrentDomain.BaseDirectory;
                settingsPath +=  @"\datalayersettings.json";
                var datalayersettings =File.ReadAllText(settingsPath);
                dynamic jSetting = JObject.Parse(datalayersettings);
                this.ConnectionString = 
                        (string)jSetting.ConnectionStrings.ConnectionString;
            }
            protected override void OnConfiguring(DbContextOptionsBuilder 
                                                  optionsBuilder)
            {
                optionsBuilder.UseSqlServer(this.ConnectionString);
            }
    }
