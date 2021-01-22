            Open("D:/Doc1.doc");
            foreach (Field myMergeField in oDoc.Fields)
            {
                //iTotalFields++;
                Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                // GET only MAILMERGE fields
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();
                    if (fieldName == "firstName")
                    {
                        myMergeField.Select();
                        oWordApplic.Selection.TypeText("This Text Replaces the Field in the Template");
                    }
                }
            }
            SaveAs("D:/Test/Doc2.doc"); Quit();
            MessageBox.Show("The file is successfully saved!");
