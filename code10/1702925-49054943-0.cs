    IDictionary<String, PdfObject> names = document.GetCatalog().GetNameTree(PdfName.Dests).GetNames();
    [...]
    if ([... some PdfOutline instance ...].GetDestination() is PdfDestination destination)
    {
        PdfObject destObject = destination.GetPdfObject();
        if (destObject is PdfString str)
        {
            destObject = names[str.ToUnicodeString()];
        }
        else if (destObject is PdfName nam)
        {
            destObject = names[nam.GetValue()];
        }
