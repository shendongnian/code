        using (Stream outStream = new FileStream("D:\\aaa\\test.pdf", FileMode.OpenOrCreate))
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, outStream);
            document.Open();
            try
            {
                PdfContentByte to = writer.DirectContent;
                to.BeginText();
                try
                {
                    to.SetFontAndSize(BaseFont.CreateFont(), 12);
                    to.SetTextMatrix(0, 0);
                    to.ShowText("aaa");
                }
                finally
                {
                    to.EndText();
                }
            }
            finally
            {
                document.Close();
            }
        }
