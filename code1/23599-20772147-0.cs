		using System.Drawing.Printing;
		
		PrintDocument printDoc = new PrintDocument();
		printDoc.DefaultPageSettings.Landscape = true;
		printDoc.DefaultPageSettings.Margins.Left = 100; //100 = 1 inch = 2.54 cm
		printDoc.DocumentName = "My Document Name"; //this can affect name of output PDF file if printer is a PDF printer
		//printDoc.PrinterSettings.PrinterName = "CutePDF";
		printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
		
		PrintDialog printDialog = new PrintDialog();
		printDialog.Document = printDoc; //Document property must be set before ShowDialog()
		DialogResult dialogResult = printDialog.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			printDoc.Print(); //start the print
		}	
		
		void printDoc_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
			string textToPrint = ".NET Printing is easy";
			Font font = new Font("Courier New", 12);
			// e.PageBounds is total page size (does not consider margins)
			// e.MarginBounds is the portion of page inside margins
			int x1 = e.MarginBounds.Left;
			int y1 = e.MarginBounds.Top;
			int w = e.MarginBounds.Width;
			int h = e.MarginBounds.Height;
			g.DrawRectangle(Pens.Red, x1, y1, w, h); //draw a rectangle around the margins of the page, also we can use: g.DrawRectangle(Pens.Red, e.MarginBounds)
			g.DrawString(textToPrint, font, Brushes.Black, x1, y1);
			e.HasMorePages = false; //set to true to continue printing next page
		}
