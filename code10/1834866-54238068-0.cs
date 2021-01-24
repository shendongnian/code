    Document doc = new Document("E:\\temp\\in.docx");
    DocumentBuilder builder = new DocumentBuilder(doc);
                
    LayoutCollector collector = new LayoutCollector(doc);
    LayoutEnumerator enumerator = new LayoutEnumerator(doc);
    
    foreach (Table table in doc.FirstSection.Body.Tables)
    {
        foreach (Row row in table.Rows)
        {
            foreach (Cell cell in row.Cells)
            {
                enumerator.Current = collector.GetEntity(cell.FirstParagraph);
                while (enumerator.Type != LayoutEntityType.Cell)
                {
                    enumerator.MoveParent();
                }
    
                double top = enumerator.Rectangle.Top + (enumerator.Rectangle.Height / 2);
                double left = enumerator.Rectangle.Left;
                double width = enumerator.Rectangle.Width;
    
                builder.MoveTo(table.NextSibling);
    
                Shape line = builder.InsertShape(ShapeType.Line, width, 0);
                line.Top = top;
                line.Left = left;
    
                line.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
                line.RelativeVerticalPosition = RelativeVerticalPosition.Page;
    
                line.BehindText = true;
                line.WrapType = WrapType.None;
                line.StrokeColor = Color.Blue;
                line.Stroke.LineStyle = ShapeLineStyle.Single;
                line.StrokeWeight = 1;
            }
        }
    }
    
    doc.Save("E:\\temp\\19.1.docx");
