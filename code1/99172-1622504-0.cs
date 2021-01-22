    using (WordprocessingDocument document = WordprocessingDocument.Open(@"C:\Path\filename.docx", true))
    {
        var mainPart = document.MainDocumentPart;
        var res = from bm in mainPart.Document.Body.Descendants<BookmarkStart>()
                  where bm.Name == "BookmarkName"
                  select bm;
        var bookmark = res.SingleOrDefault();
        if (bookmark != null)
        {
            var parent = bookmark.Parent;   // bookmark's parent element
    
            // simple paragraph in one declaration
            //Paragraph newParagraph = new Paragraph(new Run(new Text("Hello, World!")));
    
            // build paragraph piece by piece
            Text text = new Text("Hello, World!");
            Run run = new Run(new RunProperties(new Bold()));
            run.Append(text);
            Paragraph newParagraph = new Paragraph(run);
    
            // insert after bookmark parent
            parent.InsertAfterSelf(newParagraph);
    
            var table = new Table(
            new TableProperties(
                new TableStyle() { Val = "TableGrid" },
                new TableWidth() { Width = 0, Type = TableWidthUnitValues.Auto }
                ),
                new TableGrid(
                    new GridColumn() { Width = (UInt32Value)1018U },
                    new GridColumn() { Width = (UInt32Value)3544U }),
            new TableRow(
                new TableCell(
                    new TableCellProperties(
                        new TableCellWidth() { Width = 0, Type = TableWidthUnitValues.Auto }),
                    new Paragraph(
                        new Run(
                            new Text("Category Name"))
                    )),
                new TableCell(
                    new TableCellProperties(
                        new TableCellWidth() { Width = 4788, Type = TableWidthUnitValues.Dxa }),
                    new Paragraph(
                        new Run(
                            new Text("Value"))
                    ))
            ),
            new TableRow(
                new TableCell(
                    new TableCellProperties(
                        new TableCellWidth() { Width = 0, Type = TableWidthUnitValues.Auto }),
                    new Paragraph(
                        new Run(
                            new Text("C1"))
                    )),
                new TableCell(
                    new TableCellProperties(
                        new TableCellWidth() { Width = 0, Type = TableWidthUnitValues.Auto }),
                    new Paragraph(
                        new Run(
                            new Text("V1"))
                    ))
            ));
    
            // insert after new paragraph
            newParagraph.InsertAfterSelf(table);
        }
    
        // close saves all parts and closes the document
        document.Close();
    }
