            int step = -1;
            List<TabPage> tabPages;
    
            private void FMain_Load(object sender, EventArgs e) {
                // save all tabpages in the list
                tabPages = new List<TabPage>();
                foreach (TabPage tp in tabSteps.TabPages) {
                    tabPages.Add(tp);
                }
                SelectNextStep();
            }
    
            private void SelectNextStep() {
                step++;
                // remove all tabs
                for (int i = tabSteps.TabPages.Count - 1; i >= 0 ; i--) {
                        tabSteps.TabPages.Remove(tabSteps.TabPages[i]);
                }
    
                // add required tab
                tabSteps.TabPages.Add(tabPages[step]);
            }
    
            private void btnNext_Click(object sender, EventArgs e) {
                SelectNextStep();
            }
