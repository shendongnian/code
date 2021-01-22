    public class TabControlHelper
    {
        private TabControl _tabControl;
        private List<KeyValuePair<TabPage, int>> _pagesIndexed;
        public TabControlHelper(TabControl tabControl)
        {
            _tabControl = tabControl;
            _pagesIndexed = new List<KeyValuePair<TabPage, int>>();
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                _pagesIndexed.Add(new KeyValuePair<TabPage, int> (tabControl.TabPages[i], i ));
            }
        }
        public void HideAllPages()
        {
            for (int i = 0; i < _pagesIndexed.Count; i++)
            {
                _tabControl.TabPages.Remove(_pagesIndexed[i].Key);
            }
        }
        public void ShowAllPages()
        {
            for (int i = 0; i < _pagesIndexed.Count; i++)
            {
                _tabControl.TabPages.Add(_pagesIndexed[i].Key);
            }
        }
        public void HidePage(TabPage tabpage)
        {
            if (!_tabControl.TabPages.Contains(tabpage)) return;
            _tabControl.TabPages.Remove(tabpage);
        }
        public void ShowPage(TabPage tabpage)
        {
            if (_tabControl.TabPages.Contains(tabpage)) return;
            InsertTabPage(GetTabPage(tabpage).Key, GetTabPage(tabpage).Value);
        }
        private void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > _tabControl.TabCount)
                throw new ArgumentException("Index out of Range.");
            _tabControl.TabPages.Add(tabpage);
            if (index < _tabControl.TabCount - 1)
                do
                {
                    SwapTabPages(tabpage, (_tabControl.TabPages[_tabControl.TabPages.IndexOf(tabpage) - 1]));
                }
                while (_tabControl.TabPages.IndexOf(tabpage) != index);
            _tabControl.SelectedTab = tabpage;
        }
        private void SwapTabPages(TabPage tabpage1, TabPage tabpage2)
        {
            if (_tabControl.TabPages.Contains(tabpage1) == false || _tabControl.TabPages.Contains(tabpage2) == false)
                throw new ArgumentException("TabPages must be in the TabControls TabPageCollection.");
            int Index1 = _tabControl.TabPages.IndexOf(tabpage1);
            int Index2 = _tabControl.TabPages.IndexOf(tabpage2);
            _tabControl.TabPages[Index1] = tabpage2;
            _tabControl.TabPages[Index2] = tabpage1;
        }
        private KeyValuePair<TabPage, int> GetTabPage(TabPage tabpage)
        {
            return _pagesIndexed.Where(p => p.Key == tabpage).First();
        }
    }
