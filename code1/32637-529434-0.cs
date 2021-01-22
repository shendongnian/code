        public int SelectedTabIndex 
        {
            set
            {
                Type pgType = typeof(PropertyGrid);
                BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
                ToolStripButton[] buttons = (ToolStripButton[]) pgType.GetField("viewTabButtons", flags).GetValue(this);
                pgType.GetMethod("SelectViewTabButton", flags).Invoke(this, new object[] { buttons[value], true });
            }
        }
