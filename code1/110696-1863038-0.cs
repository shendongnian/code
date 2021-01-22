                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Personal Document File (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK) {
                    String filename = Path.GetTempFileName() + ".rtf";
                    using (StreamWriter sw = new StreamWriter(filename)) {
                        sw.Write(previous);
                    }
                    Object oMissing = System.Reflection.Missing.Value;    //null for VB
                    Object oTrue = true;
                    Object oFalse = false;
                    Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
                    oWord.Visible = false;
                    Object rtfFile = filename;
                    Object saveLoc = sfd.FileName;
                    Object wdFormatPDF = 17;    //WdSaveFormat Enumeration
                    oWordDoc = oWord.Documents.Add(ref rtfFile, ref oMissing, ref oMissing, ref oMissing);
                    oWordDoc.SaveAs(ref saveLoc, ref wdFormatPDF, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                         ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                    oWord.Quit(ref oFalse, ref oMissing, ref oMissing);
                    
                    //Get the MD5 hash and save it with it
                    FileStream file = new FileStream(sfd.FileName, FileMode.Open);
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] retVal = md5.ComputeHash(file);
                    file.Close();
                    using (StreamWriter sw = new StreamWriter(sfd.FileName + ".md5")) {
                        sw.WriteLine(sfd.FileName + " - " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() + " md5: " + BinaryToHexConverter.To64CharChunks(retVal)[0]);
                    }
                }
