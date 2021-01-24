        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0) throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                PaperSize pkCustomSize1 = new PaperSize("First custom size", 350, 700);
                printDoc.DefaultPageSettings.PaperSize = pkCustomSize1;
                printDoc.Print();
            }
        }
