        // helper - create a new tabpage
        static private TabPage _AddTabPage( TabControl tabControl, string caption )
        {
            int pageIndex = tabControl.TabPages.Count;
            tabControl.TabPages.Add(caption);
            return tabControl.TabPages[pageIndex];
        }
