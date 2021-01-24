           public void writeDocument()
              {
              Document _document = new Document(new Rectangle(PageSize.A3));
              var table = new PdfPTable(2);
              PdfPCell[] cells = new PdfPCell[2];
              PdfPCell cell = new PdfPCell(); 
              cell.Border = PdfPCell.NO_BORDER;
              cell.BackgroundColor = new iTextSharp.text.Color(51, 102,102);
              cells[0] = new PdfPCell(cell);
              iTextSharp.text.Image logo =         
         
    iTextSharp.text.Image.GetInstance(Server.MapPath("/logos/my_logo.png"));
              PdfPCell cell1 = new PdfPCell(); 
               cell1.Border = PdfPCell.NO_BORDER;
              cell1.Image =logo ;
              cells[1] = new PdfPCell(cell1);
    
             PdfPRow row = new PdfPRow(cells);
             table.Rows.Add(row);
            _document.Add(table);
             
             }
