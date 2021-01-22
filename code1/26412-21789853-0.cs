    private int currentTab = 0;
    private void frmOneTimeEntry_Load(object sender, EventArgs e)
        {
            tabMenu.Selecting += new TabControlCancelEventHandler(tabMenu_Selecting);
        }
    private void tabMenu_Selecting(object sender, TabControlCancelEventArgs e)
        {
            tabMenu.SelectTab(currentTab);
        }
    private void btnNextStep_Click(object sender, EventArgs e)
        {
            switch(tabMenu.SelectedIndex)
                case 0:
                    //if conditions met GoTo
                case 2:
                    //if conditions met GoTo
                case n:
                    //if conditions met GoTo
            CanLeaveTab:
                currentTab++;
                 tabMenu.SelectTab(tabMenu.SelectedIndex + 1);
                if (tabMenu.SelectedIndex == 3)
                    btnNextStep.Enabled = false;
                if (btnBackStep.Enabled == false)
                    btnBackStep.Enabled = true;
         
            CannotLeaveTab:
            
        }
        private void btnBackStep_Click(object sender, EventArgs e)
        {
            currentTab--;
            tabMenu.SelectTab(tabMenu.SelectedIndex - 1);
            if (tabMenu.SelectedIndex == 0)
                btnBackStep.Enabled = false;
            if (btnNextStep.Enabled == false)
                btnNextStep.Enabled = true;
        }
