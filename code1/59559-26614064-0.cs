        private void listViewTriggers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView triggerView = sender as ListView;
            if (triggerView != null)
            {
                btnEditTrigger_Click(null, null);
            }
        }
