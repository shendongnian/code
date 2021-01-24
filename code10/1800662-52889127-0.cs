    Dictionary<IXLAddress, ClosedXML.Excel.Drawings.IXLPicture> PicturesByCellAddress
        = new Dictionary<IXLAddress, ClosedXML.Excel.Drawings.IXLPicture>();
    foreach (ClosedXML.Excel.Drawings.IXLPicture pic in worksheet.Pictures)
    {
        PicturesByCellAddress.Add(pic.TopLeftCellAddress, pic);
    }
