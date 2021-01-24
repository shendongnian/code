            /// <summary>
        /// A test to see if word is working
        /// this function takes a valid word document and converts it to a PDF 
        /// and takes the user to explorer with the converted file selected
        /// </summary>
        /// <param name="WordDocIn">a valid path\filename to an existing word document (doc, docx, rtf, htm, mhtml</param>
        /// <returns>returns False if there are no errors and the function completed successfully</returns>
        private bool WordToPDF(string WordDocIn)
        {
            // check and make sure our file parameter actually exists
            if(!File.Exists(WordDocIn))
            {
                MessageBox.Show("The file does not exist\n\n" + WordDocIn + "\n\n", "Office Assist: Error()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // true meaning there are errors
            }
            string tmpFilename = WordDocIn;
            // create a temp filename in temp directory
            string opFileName = GetTempFilePathWithExtension("pdf");
            // set our return value
            bool ErrorsPresent = false; // false meaning there are NO errors
            // create our word app
            Word.Application wordApp = new Word.Application();
            // get our documents collection (if any)
            Word.Documents d = wordApp.Documents;
            // create our new document
            Word.Document wrdDoc = new Word.Document();
            // create our word options
            object saveOption = false;// Word.WdSaveOptions.wdDoNotSaveChanges;
            // create our missing object
            object oMissing = Type.Missing; ;// Type.Missing;
            try
            {
                // set the word app visisble for the moment sp
                // we can see what we're doing
                wordApp.Visible = false;
                // suppress our alerts
                wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                // we dont need any addins - unload all of our addins
                // need to open word with no addins loaded ... 
                wordApp.AddIns.Unload(true);   // True to remove the unloaded add-ins from the AddIns collection 
                                                // (the names are removed from the Templates and Add-ins dialog box). 
                                                // False to leave the unloaded add-ins in the collection.
                // open the document with the tmofilename
                wrdDoc = d.Open(tmpFilename, Visible: true);
                //set the page size ... to A4 (note this will throw an error if the default printer does not produce A4)
                wrdDoc.PageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;
                //
                // export our document to a PDF
                //
                wrdDoc.ExportAsFixedFormat(OutputFileName: opFileName, ExportFormat: Word.WdExportFormat.wdExportFormatPDF,
                OpenAfterExport: false, OptimizeFor: Word.WdExportOptimizeFor.wdExportOptimizeForPrint,
                Range: Word.WdExportRange.wdExportAllDocument, From: 0, To: 0, Item: Word.WdExportItem.wdExportDocumentContent,
                IncludeDocProps: true, KeepIRM: true, CreateBookmarks: Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                DocStructureTags: true, BitmapMissingFonts: true, UseISO19005_1: false);
                // trick our Word App into thinking that the document has been saved
                wrdDoc.Saved = true;
                // close our word document
                wrdDoc.Close(ref saveOption, ref oMissing, ref oMissing);
                // close our documents collection
                //d.Close(ref saveOption, ref oMissing, ref oMissing);
                foreach (Word.Template template in wordApp.Templates)
                {
                    switch (template.Name.ToLower())
                    {
                        case "normal.dotm":
                            template.Saved = true;
                            break;
                    }
                }
                // quit word
                wordApp.Quit(ref saveOption, ref oMissing, ref oMissing);
            }
            // catch our errors
            catch (COMException es)
            {
                string errcode = "ComException : " + es.Message + "\n\n" + "Show this message to your admin";
                MessageBox.Show("Check the default printer has the ability to print A4\nSelect a new printer and try again\n\n" + errcode, "Office Assist: Error()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorsPresent = true;
                //throw (es);
            }
            catch (Exception es)
            {
                string errcode = "Exception : " + es.Message + " \n\n " + "Show this message to your admin";
                MessageBox.Show(errcode, "Office Assist: Error()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorsPresent = true;
                //throw (es);
            }
            finally
            {
                try
                {
                    // release our objects
                    Marshal.ReleaseComObject(wrdDoc);
                    Marshal.ReleaseComObject(d);
                    Marshal.ReleaseComObject(wordApp);
                }
                catch (Exception es)
                {
                    string errcode = "Exception : " + es.Message + " \n\n " + "Show this message to your admin";
                    MessageBox.Show(errcode, "Office Assist: Error()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorsPresent = true;
                }
            }
            // if there are no errors present
            // open explorer and select the pdf created
            //
            if (!ErrorsPresent)
            {
                // set our switches
                string argument = "/select, \"" + opFileName + "\"";
                // open explorer and select the file
                Process.Start("explorer.exe", argument);
            }
            return ErrorsPresent;
        }
