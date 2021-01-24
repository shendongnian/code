    private void WriteListToPdf(Document doc)
    {
        Table table = new Table(2, true);
        foreach (var item in myList)
        {
            table.AddCell(new Paragraph(item.Foo));
            table.AddCell(new Paragraph(item.Bar));
        }
        doc.Add(table);
    }
