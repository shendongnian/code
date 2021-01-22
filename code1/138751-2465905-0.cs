        public void SaveSheetToPdf(FileInfo outputPDF)
        {
        	FileInfo documentFile = new FileInfo(Globals.ThisWorkbook.Path + @"\tempDoc.xps");
        	if (documentFile.Exists)
        		documentFile.Delete();
        
        	Globals.Sheet2.PrintOut(1, missing, 1, false, "Microsoft XPS Document Writer", true, false, documentFile.FullName);
        
        	Doc theDoc = new Doc();                
        					
        	try
        	{
        		MyImportOperation importOp = new MyImportOperation(theDoc);
        		importOp.Import(documentFile);            
        	}
        	catch (Exception ex)
        	{
        		throw new Exception("Error rendering pdf. PDF Source XPS Path: " + investmentPlanXPSPath, ex);
        	}
        
        	theDoc.Save(outputPDF.FullName);
        }
        
        public class MyImportOperation
        {
           private Doc _doc = null;
           private double _margin = 10;
           private int _pagesAdded = 0;
        
           public MyImportOperation(Doc doc)
           {
        	   _doc = doc;
           }
        
        public void Import(string inPath)
        {
        	using (XpsImportOperation op = new XpsImportOperation())
        	{
        		op.ProcessingObject += Processing;
        		op.ProcessedObject += Processed;
        		op.Import(_doc, inPath);
        	}
        }
        
        public void Processing(object sender, ProcessingObjectEventArgs e)
        {
        	
        	if (e.Info.SourceType == ProcessingSourceType.PageContent)
        	{		
        		_doc.Page = _doc.AddPage();		
        		e.Info.Handled = true;
        		_pagesAdded++;
        	}
        }
        
        public void Processed(object sender, ProcessedObjectEventArgs e)
        {
        	if (e.Successful)
        	{
        		PixMap pixmap = e.Object as PixMap;
        		if (pixmap != null)
        			pixmap.Compress();		
        	}
        }
    
    }
