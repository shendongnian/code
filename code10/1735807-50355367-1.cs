    Microsoft.Office.Interop.Word.Application WordApplication = new Microsoft.Office.Interop.Word.Application();
    Microsoft.Office.Interop.Word.Document DefaultDocument;
    DefaultDocument = WordApplication.Documents.Open(FilePath);
    CultureInfo culture = new CultureInfo((int)DefaultDocument.Content.LanguageID);
    string SaveFileName = Path.Combine(Path.GetDirectoryName(FilePath), 
                                       Path.GetFileNameWithoutExtension(FilePath));
    DefaultDocument.SaveAs2(SaveFileName, WdSaveFormat.wdFormatEncodedText, Type.Missing, 
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                            Type.Missing, Type.Missing, Type.Missing, 
                            MsoEncoding.msoEncodingUnicodeLittleEndian, Type.Missing, Type.Missing, 
                            Type.Missing, true); //<- BiDi Marks
    //Release the Document
    foreach (Document WDocument in WordApplication.Documents)
    {
        WDocument.Close(WdSaveOptions.wdDoNotSaveChanges);
        Marshal.ReleaseComObject(WDocument);
    }
    //Release the WINWORD Process
    WordApplication.Quit(WdSaveOptions.wdDoNotSaveChanges);
    Marshal.ReleaseComObject(WordApplication);
    Marshal.CleanupUnusedObjectsInCurrentContext();
    //Test the results using a RichTextBox
    richTextBox1.RightToLeft = (culture.TextInfo.IsRightToLeft) ? RightToLeft.Yes : RightToLeft.No;
    richTextBox1.ImeMode = ImeMode.On;
    richTextBox1.Text = File.ReadAllText(SaveFileName + ".txt");
