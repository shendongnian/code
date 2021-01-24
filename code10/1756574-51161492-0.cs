         private void CreateDocument()
         {
            try
            {
                var doc = DocX.Create("mytest.docx");
                doc.InsertParagraph("Hello my new message");
                doc.Save();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } 
        }
