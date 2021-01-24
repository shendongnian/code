    var tableCells =
                report.AllObjects.ToArray().Where(item => item.GetType() == typeof(TableCell)).Cast<TableCell>();
    
    foreach (var tableCell in tableCells)
    {
        tableCell.TextRenderType = TextRenderType.HtmlParagraph;
    }
