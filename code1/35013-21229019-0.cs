    using System.Windows.Forms;
    
    namespace ExtensionMethods
    {
        public static class TabPageExtensions
        {
    
            public static bool IsVisible(this TabPage tabPage)
            {
                if (tabPage.Parent == null)
                    return false;
                else if (tabPage.Parent.Contains(tabPage))
                    return true;
                else
                    return false;
            }
    
            public static void HidePage(this TabPage tabPage)
            {
                TabControl parent = (TabControl)tabPage.Parent;
                parent.TabPages.Remove(tabPage);
            }
    
            public static void ShowPageInTabControl(this TabPage tabPage,TabControl parent)
            {
                parent.TabPages.Add(tabPage);
            }
        }
    }
