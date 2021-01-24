            // Load source PDF file
            PdfFileInfo info = new PdfFileInfo();
            info.BindPdf(dataDir + "Test.pdf");
            if (info.IsEncrypted)
            {
                // Determine if the source PDF is encrypted
                Console.WriteLine("File is encrypted");
            }
            if (info.HasEditPassword)
            {
                // Determine if the source PDF has edit password
                Console.WriteLine("File has edit password");
            }
            if (info.HasOpenPassword)
            {
                // Determine if the source PDF has open password
                Console.WriteLine("File has open password");
            }
