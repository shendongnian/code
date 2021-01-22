    private void ThisAddIn_AttachmentContextMenuDisplay(Office.CommandBar commandBar, Outlook.AttachmentSelection attachments)
    {
        if (attachments.Count > 0)
        {
            Office.CommandBarControl cbc = commandBar.Controls.Add(
                      Office.MsoControlType.msoControlButton, 
                      missing, missing, missing, true);
            cbc.Caption = "Export into SuperOffice";
            cbc.OnAction = "Action";
        }
    }
