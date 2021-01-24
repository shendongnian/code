    private Outlook.Items _items;
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Outlook.Application application = this.Application;
    
            _items = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).Items;
            _items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Items_ItemAdd);
        }
