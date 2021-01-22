    public static void Sort(TabControl tabControl)
    {
        var tabList = tabControl.TabPages.Cast<TabPage>().ToList();
        tabList.Sort(new TabPageComparer());
        tabControl.TabPages.Clear();
        tabControl.TabPages.AddRange(tabList.ToArray());
    }
   
    public class TabPageComparer : IComparer<TabPage>
    {
        public int Compare(TabPage x, TabPage y)
        {
            return string.Compare(x.Text, y.Text);
        }
    }
