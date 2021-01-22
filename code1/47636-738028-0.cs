    public class TabRenderer
    {
        private TabControl _tabControl;
    
        public TabRenderer(TabControl tabControl)
        {
            _tabControl = tabControl;
            _tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            _tabControl.DrawItem += TabControlDrawItem;
        }
    
        private void TabControlDrawItem(object sender, DrawItemEventArgs e)
        {
       		// Your drawing code...
        }
    }
