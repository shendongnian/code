    public class TabControlHelper {
        private TabControl tc;
        private List<TabPage> pages;
        public TabControlHelper(TabControl tabControl) {
            tc = tabControl;
            pages = new List<TabPage>();
            foreach (TabPage p in tc.TabPages) {
                pages.Add(p);
            }
        }
        public void HideAllPages() {
            foreach(TabPage p in pages) {
                tc.TabPages.Remove(p);
            }
        }
        public void ShowAllPages() {
            foreach (TabPage p in pages) {
                tc.TabPages.Add(p);
            }
        }
        public void HidePage(TabPage tp) {
            tc.TabPages.Remove(tp);
        }        
        public void ShowPage(TabPage tp) {
            tc.TabPages.Add(tp);
        }
    }  
