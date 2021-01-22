    public static PdfPCell GetCell(string strText, Font font)
    {
        PdfPCell cell = new PdfPCell(new Phrase(strText, font));
        cell.Border = 0;
        return cell;
    }
    var cell = GetCell("...", GetDefaultFont());
