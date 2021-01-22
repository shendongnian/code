    public class RefreshingToolStripComboBox : ToolStripComboBox
    {
        // We do not want "fake" selectedIndex change events etc, subclass that overide the OnIndexChanged etc
        // will have to check InOnCultureChanged them selfs
        private bool inRefresh = false;
        public bool InRefresh { get { return inRefresh; } }
        public void Refresh()
        {
            try
            {
                inRefresh = true;
                // This is harder then it shold be, as I can't get to the Refesh method that
                // is on the embebed combro box.
                //
                // I am trying to get ToString recalled on all the items
                int selectedIndex = SelectedIndex;
                object[] items = new object[Items.Count];
                Items.CopyTo(items, 0);
                Items.Clear();
                Items.AddRange(items);
                SelectedIndex = selectedIndex;
            }
            finally
            {
                inRefresh = false;
            }
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!inRefresh)
            {
                base.OnSelectedIndexChanged(e);
            }
        }
    }
