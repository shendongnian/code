    using Outlook = Microsoft.Office.Interop.Outlook;
    // ...
    string advancedSearchTag = "Our first advanced search in Outlook";
 
    private void RunAdvancedSearch(Outlook._Application OutlookApp, string wordInSubject)
    {
      string scope = "Inbox";
      string filter = "urn:schemas:mailheader:subject LIKE \'%"+ wordInSubject +"%\'";            
      Outlook.Search advancedSearch = null;
      Outlook.MAPIFolder folderInbox = null;
      Outlook.MAPIFolder folderSentMail = null;
      Outlook.NameSpace ns = null;
      try
      {
        ns = OutlookApp.GetNamespace("MAPI");
        folderInbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        folderSentMail = ns.GetDefaultFolder(
                                       Outlook.OlDefaultFolders.olFolderSentMail);
        scope = "\'" + folderInbox.FolderPath + 
                                      "\',\'" + folderSentMail.FolderPath + "\'";
        advancedSearch = OutlookApp.AdvancedSearch(
                                        scope, filter, true, advancedSearchTag );
      }
      catch(Exception ex)
      {
         MessageBox.Show(ex.Message, "An eexception is thrown");
      }
      finally
      {
         if(advancedSearch!=null) Marshal.ReleaseComObject(advancedSearch);
         if (folderSentMail != null) Marshal.ReleaseComObject(folderSentMail);
         if (folderInbox != null) Marshal.ReleaseComObject(folderInbox);
         if (ns != null) Marshal.ReleaseComObject(ns);
      }                
    }
 
    private void adxOutlookEvents_AdvancedSearchComplete(object sender, object hostObj)
    {
      Outlook.Search advancedSearch = null;
      Outlook.Results advancedSearchResults = null;
      Outlook.MailItem resultItem = null;
      System.Text.StringBuilder strBuilder = null;
      try
      {
        advancedSearch = hostObj as Outlook.Search;
        if (advancedSearch.Tag == advancedSearchTag)
        {
            advancedSearchResults = advancedSearch.Results;
            if (advancedSearchResults.Count > 0)
            {
                if (HostMajorVersion > 10)
                {
                    object folder = advancedSearch.GetType().InvokeMember("Save", 
                                       System.Reflection.BindingFlags.Instance |
                                       System.Reflection.BindingFlags.InvokeMethod | 
                                       System.Reflection.BindingFlags.Public,
                                       null, advancedSearch, 
                                       new object[] { advancedSearchTag });
 
                }
                else
                {
                    strBuilder = new System.Text.StringBuilder();
                    strBuilder.AppendLine("Number of items found: " +
                              advancedSearchResults.Count.ToString());                            
                    for (int i = 1; i < = advancedSearchResults.Count; i++)
                    {                                
                        resultItem = advancedSearchResults[i] 
                                          as Outlook.MailItem;
                        if (resultItem != null)
                        {
                            strBuilder.Append("#" + i.ToString());
                            strBuilder.Append(" Subject: " + resultItem.Subject);
                            strBuilder.Append(" \t To: " + resultItem.To);
                            strBuilder.AppendLine(" \t Importance: " + 
                                               resultItem.Importance.ToString());
                            Marshal.ReleaseComObject(resultItem);
                        }
                    }
                    if (strBuilder.Length > 0)
                        System.Diagnostics.Debug.WriteLine(strBuilder.ToString());   
                    else
                        System.Diagnostics.Debug.WriteLine(
                                                "There are no Mail items found.");
                 }
              }
              else
              {
                 System.Diagnostics.Debug.WriteLine("There are no items found.");
              }
           }
        }
        catch (Exception ex)
        {
           MessageBox.Show(ex.Message, "An exception is occured");
        }
        finally
        {
          if (resultItem != null) Marshal.ReleaseComObject(resultItem);
          if (advancedSearchResults != null) 
                     Marshal.ReleaseComObject(advancedSearchResults); 
        }
      }
