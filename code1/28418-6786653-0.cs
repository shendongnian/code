        Microsoft.Office.Interop.Outlook.Application outapp = new Application();
        try
        {
            
            _NameSpace np = outapp.GetNamespace("MAPI");
            MailItem oMsg = (MailItem)outapp.CreateItem(OlItemType.olMailItem);
            oMsg.To = "a@b.com";
            oMsg.Subject = "Subject";
            
           //add detail
           
            oMsg.SaveAs("C:\\Doc.msg", OlSaveAsType.olMSGUnicode);//your path
            oMsg.Close(OlInspectorClose.olSave);
        }
        catch (System.Exception e)
        {
            status = false;
        }
        finally
        {
            outapp.Quit();
        }
