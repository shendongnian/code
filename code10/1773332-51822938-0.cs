    Word.Document DocForPrint = wdApp.Documents.Add();
    Word.Range docRange = DocForPrint.Content;
    Word.InlineShape picShape = docRange.InlineShapes.AddPicture(imgPath);
    picShape.Width = wdApp.CentimetersToPoints(21.89f);
    picShape.Height = wdApp.CentimetersToPoints(15.6f); 
