    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        outlookNameSpace = this.Application.GetNamespace("MAPI");
        inbox = outlookNameSpace.GetDefaultFolder(
                        Microsoft.Office.Interop.Outlook.
                        OlDefaultFolders.olFolderInbox);
        items = inbox.Items;
        items.Sort("[ReceivedTime]", true);
        Outlook.TableView CurView = ((Outlook.TableView)inbox.CurrentView);
        var viewField = CurView.ViewFields["Categories"];
        var columnFormat = viewField.ColumnFormat;
        columnFormat.Align = Outlook.OlAlign.olAlignRight;
        columnFormat.Width = 10;
        CurView.Save();
        CurView.Apply();
    }
