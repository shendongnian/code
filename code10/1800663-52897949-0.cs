    Dictionary<int, ClosedXML.Excel.Drawings.IXLPicture> PicturesByCellAddress
		= new Dictionary<int, ClosedXML.Excel.Drawings.IXLPicture>();
						foreach (ClosedXML.Excel.Drawings.IXLPicture pic in hoja.Pictures)
						{
							try { PicturesByCellAddress.Add(pic.TopLeftCellAddress.RowNumber, pic); }
							catch { }
						}
