    public enum ConfigurationSection
    {
        AppSettings
    }
    
    public static class Utility
    {
        #region "Common.Configuration.Configurations"
    
        private static Cache cache = System.Web.HttpRuntime.Cache;
    
        public static String GetAppSetting(String key)
        {
            return GetConfigurationValue(ConfigurationSection.AppSettings, key);
        }
    
        public static String GetConfigurationValue(ConfigurationSection section, String key)
        {
            Configurations config = null;
    
            if (!cache.TryGetItemFromCache<Configurations>(out config))
            {
                config = new Configurations();
                config.List(SNCLavalin.US.Common.Enumerations.ConfigurationSection.AppSettings);
                cache.AddToCache<Configurations>(config, DateTime.Now.AddMinutes(15));
            }
    
            var result = (from record in config
                          where record.Key == key
                          select record).FirstOrDefault();
    
            return (result == null) ? null : result.Value;
        }
    
        #endregion
    }
    
    namespace Common.Configuration
    {
        public class Configurations : List<Configuration>
        {
            #region CONSTRUCTORS
    
            public Configurations() : base()
            {
                initialize();
            }
            public Configurations(int capacity) : base(capacity)
            {
                initialize();
            }
            public Configurations(IEnumerable<Configuration> collection) : base(collection)
            {
                initialize();
            }
            
            #endregion
    
            #region PROPERTIES & FIELDS
    
            private Crud _crud; // Db-Access layer
    
            #endregion
    
            #region EVENTS
            #endregion
    
            #region METHODS
    
            private void initialize()
            {
                _crud = new Crud(Utility.ConnectionName);
            }
    
            /// <summary>
            /// Lists one-to-many records.
            /// </summary>
            public Configurations List(ConfigurationSection section)
            {
                using (DbCommand dbCommand = _crud.Db.GetStoredProcCommand("spa_LIST_MyConfiguration"))
                {
                    _crud.Db.AddInParameter(dbCommand, "@Section", DbType.String, section.ToString());
    
                    _crud.List(dbCommand, PopulateFrom);
                }
    
                return this;
            }
    
            public void PopulateFrom(DataTable table)
            {
                this.Clear();
    
                foreach (DataRow row in table.Rows)
                {
                    Configuration instance = new Configuration();
                    instance.PopulateFrom(row);
                    this.Add(instance);
                }
            }
    
            #endregion
        }
    
        public class Configuration
        {
            #region CONSTRUCTORS
            
            public Configuration()
            {
                initialize();
            }
            
            #endregion
    
            #region PROPERTIES & FIELDS
    
            private Crud _crud;
    
            public string Section { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }
    
            #endregion
    
            #region EVENTS
            #endregion
    
            #region METHODS
    
            private void initialize()
            {
                _crud = new Crud(Utility.ConnectionName);
                Clear();
            }
    
            public void Clear()
            {
                this.Section = "";
                this.Key = "";
                this.Value = "";
            }
            public void PopulateFrom(DataRow row)
            {
                Clear();
    
                this.Section = row["Section"].ToString();
                this.Key = row["Key"].ToString();
                this.Value = row["Value"].ToString();
            }
    
            #endregion
        }
    }
