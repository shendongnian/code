        List<SettingItem> settingItems;
        public IEnumerable<SettingItem> Settings
        {
            get
            {
                return settingItems.OrderBy(t => t.Name).AsEnumerable();
            }
            set
            {
                if (value == null)
                {
                    settingItems.Clear();
                }
                else
                {
                    settingItems = value.ToList();
                }
            }
        }
