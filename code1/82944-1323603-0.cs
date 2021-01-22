        private int _oldIndex = -1;
        private void tabControl1_Deselected(object sender, TabControlEventArgs e)
        {
            _oldIndex = e.TabPageIndex;
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_oldIndex != -1)
            {
                if (CanChangeTab(_oldIndex, e.TabPageIndex))
                {
                    e.Cancel = true;
                }
            }
        }
        private bool CanChangeTab(int fromIndex, int toIndex)
        {
            // Put your logic here
        }
