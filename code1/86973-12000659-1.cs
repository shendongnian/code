        public IEnumerable<object> ContextMenu
        {
            get
            {
                // ToArray() needed or else they get garbage collected
                return GetContextMenu().ToArray();
            }
        }
        public IEnumerable<object> GetContextMenu()
        {
            yield return new MenuItemViewModel()
            {
                Text = "Clear all flags",
            };
            // adds a normal 'Separator' menuitem
            yield return new Separator();
            yield return new MenuItemViewModel()
            {
                Text = "High Priority"
            };
            yield return new MenuItemViewModel()
            {
                Text = "Medium Priority"
            };
            
            yield return new MenuItemViewModel()
            {
                Text = "Low Priority"
            };
            yield break;
        }
