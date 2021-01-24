    public partial class ThisAddIn
    {
       private Outlook.Explorer currentExplorer = null;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            currentExplorer = this.Application.ActiveExplorer();
            currentExplorer.SelectionChange += ExplorerSelectionChange;
        }
        private void ExplorerSelectionChange()
        {
            if (this.Application.ActiveExplorer().Selection.Count > 0)
            {
                Object selItem = this.Application.ActiveExplorer().Selection[1];
                if (selItem is Outlook.MailItem && !string.IsNullOrEmpty(crminfoURL))
                {
                    Outlook.MailItem mailItem = (selItem as Outlook.MailItem);
                    string bodyText= mailItem.Body; //GET PlainTExt
                     string bodyHTML=mailItem.HTMLBody; //Get HTMLFormat
                 }
             }
         }
    }
