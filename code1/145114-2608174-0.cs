    public static PdfPCell GetCell(string strText, Func<Font> fontCreator)
    {
        PdfPCell cell = new PdfPCell(new Phrase(strText, fontCreator()));
        cell.Border = 0;
        return cell;
    }
    var cell = GetCell("...", () => GetDefaultFont());
