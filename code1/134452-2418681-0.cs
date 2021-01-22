      private void AddButtonToNewDropdown()
        {
            Office.CommandBar commandBar = this.Application.ActiveExplorer().CommandBars["Standard"];
            Office.CommandBarControl ctl = commandBar.Controls["&New"];
            if (ctl is Office.CommandBarPopup)
            {
                Office.CommandBarPopup newpopup = (Office.CommandBarPopup)ctl;
                commandBarButton = (Office.CommandBarButton)newpopup.Controls.Add(1, missing, missing, missing, true);
                commandBarButton.Caption = "My custom button";
                commandBarButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(ButtonClick);
            }
                        
        }
