    public void SetExplorerSelection(string emailID)
    {
        //Get Outlook namespace
        var oApp = Globals.ThisAddIn.Application;
        var oNS = oApp.GetNamespace("mapi");
        //Get the Active Explorer
        Microsoft.Office.Interop.Outlook.Explorer activeExplorer = oApp.ActiveExplorer();
        //Clear the current selection
        activeExplorer.ClearSelection();
        //Get the Mail Item
		try
		{
			MailItem mailItem = oNS.GetItemFromID(emailID);
			if (activeExplorer.IsItemSelectableInView(mailItem))
			{
				//Show the item in the Explorer
				activeExplorer.AddToSelection(mailItem);
				return;
			}
			else
			{
				int flag = 0;
				foreach(Microsoft.Office.Interop.Outlook.MAPIFolder myDestFolder in oNS.Folders[mailItem.ReceivedByName].Folders)
				{
					activeExplorer.CurrentFolder = myDestFolder;
					foreach (Microsoft.Office.Interop.Outlook.View tmp in myDestFolder.Views)
					{
						try
						{
							activeExplorer.CurrentView = tmp;
							activeExplorer.ClearSelection();
							activeExplorer.AddToSelection(item);
							
							tmp.Reset();
							tmp.Apply();
							
							flag = 1;
							break;
						}
						catch
						{
							continue;
						}
					}
					
					if(flag ==1 )
						break;
				}
				
			}
		}
		catch
		{
			MessageBox.Show("It is deleted message");
		}
    }
