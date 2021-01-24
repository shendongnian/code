    public static class ConfigInterOps
    {
        public static IEnumerable<MemberInfo> GetAttributes(Type type)
        {
            return type.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property ||
                    x.MemberType == MemberTypes.Field);
        }
    }
    public static class ConfigIO
    {
        public static void Save(Config cfg)
        {
            UseDefaultLocation(cfg);
            if (!File.Exists(cfg.FileLocation))
            {
                File.Create(cfg.FileLocation);
            }
            File.WriteAllText(cfg.FileLocation, JsonConvert.SerializeObject(cfg));
        }
        private static void UseDefaultLocation(Config cfg)
        {
            cfg.FileLocation = cfg.FileLocation ?? Path.Combine($"{AppContext.BaseDirectory}", "conf.jobj");
        }
        public static Config OpenDefault()
        {
            var cfg = new Config();
            UseDefaultLocation(cfg);
            return Open(cfg);            
        }
        public static Config Open(Config config)
        {
            var text = File.ReadAllText(config.FileLocation);
            Config openedCfg = JsonConvert.DeserializeObject<Config>(text);
            return openedCfg;
        }
    }
