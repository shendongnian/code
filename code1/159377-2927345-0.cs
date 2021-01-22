    tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
       void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            //validate the current page, to cancel the select use:
            e.Cancel = true;
        }
