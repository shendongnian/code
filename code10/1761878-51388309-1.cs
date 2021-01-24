    public void WritePartsPdf(Document doc)
    {
        Table table = new Table(2, true);
        foreach (var part in PartsList)
        {
            var name = new Paragraph(part.PartName);
            var length = new Paragraph(part.Length.ToString());
            var column1 = new Cell().Add(name);
            var column2 = new Cell().Add(length);
            table.AddCell(column1);
            table.AddCell(column2);
        }
        doc.Add(table);
    }
