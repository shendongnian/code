        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Outlook.Folder taskList =Application.Session.GetDefaultFolder(
       Outlook.OlDefaultFolders.olFolderTasks)
       as Outlook.Folder;
            Outlook.TaskItem taskItem = taskList.Items.Add(
              "IPM.Task.twoformMssges") as Outlook.TaskItem;
            taskItem.Subject = "IPM.Task.twoformMssges Created On " +
              System.DateTime.Now.ToLongDateString();
            taskItem.Save();
            Outlook.MAPIFolder primarytaskfolder = (Outlook.MAPIFolder)
              this.Application.ActiveExplorer().Session.GetDefaultFolder
               (Outlook.OlDefaultFolders.olFolderTasks);
            Outlook.MAPIFolder settaskfolder = primarytaskfolder.Folders["testassociation"];
              Outlook.Application app = this.Application;
            string formpropstring= "twotabs";
           // PublishFormToPersonalFormsLibrary(taskItem,settaskfolder, "c:\\" , "IPM.Task.twoformMssges",registryname, registryname,registryname + "version 0.0.0.1", "0.0.0.1", Application);
            object missing = System.Reflection.Missing.Value;
            string existingVersion = "";
             try
             {
                
                if (taskItem != null)
                {
                 
                    Type existingItemType = taskItem.GetType();
                    Outlook.FormDescription existingFormDescription = (Outlook.FormDescription)existingItemType.InvokeMember("FormDescription", System.Reflection.BindingFlags.GetProperty, null, taskItem, null);
                    //if (debugmode) writer.WriteToLog("formdescription allocated to existingformdescription");
                    // get the installed version
                    existingVersion = existingFormDescription.Version;
                    // discard the temporary item
                    object[] args = { Outlook.OlInspectorClose.olDiscard };
                    existingItemType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod, null, taskItem, args);
                    //if (debugmode) writer.WriteToLog("GarbageCollection");
                }
            }
            catch (System.Exception ex)
            {
            }
            Type itemType = taskItem.GetType();
            Outlook.FormDescription formDescription = (Outlook.FormDescription)itemType.InvokeMember("FormDescription", System.Reflection.BindingFlags.GetProperty, null, taskItem, null);
            // Apply some Parameters to the Formdescription
            formDescription.Name = formpropstring;
            formDescription.DisplayName = formpropstring;
            formDescription.Category = "uncategorized";
            formDescription.Comment = formpropstring;
            formDescription.Version = "0.0.0.1";
           
            //formDescription.PublishForm(Microsoft.Office.Interop.Outlook.OlFormRegistry.olPersonalRegistry );
            formDescription.PublishForm(Microsoft.Office.Interop.Outlook.OlFormRegistry.olFolderRegistry, settaskfolder);
            //if (debugmode) writer.WriteToLog("associating complete");
            Outlook.PropertyAccessor objPA = settaskfolder.PropertyAccessor;
            string strBaseType;
            string strMsg;
            int intLoc;
            bool blnBadForm;
            int i;
            string PR_DEF_POST_MSGCLASS =
              "http://schemas.microsoft.com/mapi/proptag/0x36E5001E";
            string PR_DEF_POST_DISPLAYNAME =
              "http://schemas.microsoft.com/mapi/proptag/0x36E6001E";
            \\string[] arrSchema = { PR_DEF_POST_MSGCLASS, PR_DEF_POST_DISPLAYNAME };
            \\string[] arrValues = { "IPM.Task.twoformMssges" , "testassociation" };
            \\string[] arrErrors;
            
            try
            {
                objPA = settaskfolder.PropertyAccessor;
                objPA.SetProperty(PR_DEF_POST_MSGCLASS, "IPM.Task.twoformMssges");
                objPA.SetProperty(PR_DEF_POST_DISPLAYNAME, "testassociation");
                //   if (debugmode) writer.WriteToLog("default folder set");
                //  arrErrors = objPA.SetProperties(arrSchema, arrValues);
            }
            catch (SystemException sex)
            {
                Console.WriteLine("This is catch with system exception : {0}", sex.ToString());
            }
    
        }
