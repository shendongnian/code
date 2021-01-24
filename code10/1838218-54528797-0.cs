    private void AddMyRowMenu2() 
    {
       Office.CommandBars commandBars = null;
       Office.CommandBar commandBarRowMenu = null;
       Office.CommandBarPopup commandBarRowPopupMenu = null;
       Office.CommandBarButton commandBarButtonMyOptions1 = null;
       Office.CommandBarButton commandBarButtonMyOptions2 = null;
       try
       {
           commandBars = (Office.CommandBars)Application.GetType().InvokeMember("CommandBars", System.Reflection.BindingFlags.GetProperty, null, Application, new object[] { });
           commandBarRowMenu = commandBars["Row"];
           commandBarRowPopupMenu = (Office.CommandBarPopup)commandBarRowMenu.Controls.Add(Office.MsoControlType.msoControlPopup, oMissing, oMissing, oMissing, oMissing);
           commandBarRowPopupMenu.Caption = "My Popup Menu 1";
           commandBarButtonMyOptions1 = (Office.CommandBarButton) commandBarRowPopupMenu.Controls.Add(Office.MsoControlType.msoControlButton, oMissing, oMissing, oMissing, oMissing);
           commandBarButtonMyOptions1.Caption = "My Button Option 1";
           commandBarButtonMyOptions2 = (Office.CommandBarButton) commandBarRowPopupMenu.Controls.Add(Office.MsoControlType.msoControlButton, oMissing, oMissing, oMissing, oMissing);
           commandBarButtonMyOptions2.Caption = "My Button Option 2";
       }
       catch (ArgumentException ex)
       {
           MessageBox.Show(ex.Message, "Test Menu Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
       }
       commandBarButtonMyOptions1.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(commandBarButtonMyOptions1_Click);
       commandBarButtonMyOptions2.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(commandBarButtonMyOptions2_Click);
    }
