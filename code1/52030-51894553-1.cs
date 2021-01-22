     string f1 = "D:\\a.pdf";
     string f2 = "D:\\Iso.pdf";
     string outfile = "D:\\c.pdf";
     appendPagesFromPdf(f1, f2, outfile, 3);
  
      public static void appendPagesFromPdf(String f1,string f2, String destinationFile, int startingindex)
            {
                PdfReader p1 = new PdfReader(f1);
                PdfReader p2 = new PdfReader(f2);
                int l1 = p1.NumberOfPages, l2 = p2.NumberOfPages;
    
    
                //Create our destination file
                using (FileStream fs = new FileStream(destinationFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document doc = new Document();
    
                    PdfWriter w = PdfWriter.GetInstance(doc, fs);
                    doc.Open();
                    for (int page = 1; page <= startingindex; page++)
                    {
                        doc.NewPage();
                        w.DirectContent.AddTemplate(w.GetImportedPage(p1, page), 0, 0);
                        //Used to pull individual pages from our source
                
                    }//  copied pages from first pdf till startingIndex
                    for (int i = 1; i <= l2;i++)
                    {
                        doc.NewPage();
                        w.DirectContent.AddTemplate(w.GetImportedPage(p2, i), 0, 0);
                    }// merges second pdf after startingIndex
                    for (int i = startingindex+1; i <= l1;i++)
                    {
                        doc.NewPage();
                        w.DirectContent.AddTemplate(w.GetImportedPage(p1, i), 0, 0);
                    }// continuing from where we left in pdf1 
    
                    doc.Close();
    
                }
            }
        
    
          
