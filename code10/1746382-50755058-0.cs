     class PerformMailMerge
        {
            Word.Application mailApp;
            Object oMissing = System.Reflection.Missing.Value;
            Object oFalse = false;
            string _path = @"Your Path to Excel File";
            string savePath = @"Your Path to Word Document";
    
            public void mailMerge2()
            {
                mailApp = new Word.Application();
                mailApp.Visible = false;
    
                mailApp.Documents.Add();
                
                mailApp.ActiveDocument.MailMerge.MainDocumentType = Word.WdMailMergeMainDocType.wdMailingLabels;
    
                //OpenDataSource: 
                mailApp.ActiveDocument.MailMerge.OpenDataSource(_path,
                    Word.WdOpenFormat.wdOpenFormatAllWordTemplates, true, true, true,
                    ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, "TABLE Tabelle1$", "SELECT * FROM `Tabelle1$",
                    ref oMissing, ref oMissing,
                    Word.WdMergeSubType.wdMergeSubTypeWord2000);
    
                mailApp.ActiveDocument.SaveAs2(savePath);
                mailApp.ActiveDocument.Close();
                mailApp.Quit();
            }    
        }
