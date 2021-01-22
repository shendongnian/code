    PdfPTable table = new PdfPTable(4); 
        table.DefaultCell.Border = 0; 
        // Added -----
        table.DefaultCell.VerticalAlignment = Element.ALIGN_BOTTOM;
        
        var empName = new Phrase("John Doe"); 
        var empIDHeading = new Phrase("EmployeeID"); 
        var empID = new Phrase("2008"); 
        var departments = new PdfPCell(CreateDepartments()) 
                         { 
                             Border = 0, 
                             NoWrap = true 
     
                         }; 
        table.AddCell(empName); 
        table.AddCell(empIDHeading ); 
        table.AddCell(empID ); 
        table.AddCell(departments); 
