    private void LoadConfig()
        {
            JsonSerializerSettings jss = new JsonSerializerSettings()
            {
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            };
            var cfg = ConfigIO.OpenDefault();
            ConfigItem ci = JsonConvert.DeserializeObject<ConfigItem>(cfg.Object);
            IEnumerable<MemberInfo> atts = ConfigInterOps.GetAttributes(typeof(ConfigItem));
            FillForm(ci, atts);
        }
    private void FillForm(Object referenceObject, IEnumerable<MemberInfo> atts)
        {
            int location = 5;
            foreach (var att in atts)
            {
                var cfg = new ConfigurationBox(att.Name, referenceObject.GetType()
                    .GetProperty(att.Name).GetValue(referenceObject, null));
                cfg.Name = $"cfg_ {att.Name}";
                cfg.Top = 3 * location;
                location += 10;
                Controls["flowLayoutPanel1"].Controls.Add(cfg);                
            }
        }
