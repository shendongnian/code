    MainDocumentPart mainPart = myDoc.MainDocumentPart;
    Body body = mainPart.Document.GetFirstChild<Body>();
    var bookmark = body.Descendants<BookmarkStart>()
                        .Where( o => o.Name == "Table" )
                        .FirstOrDefault();
    var parent = bookmark.Parent; //bookmark's parent element
    if (ds!=null)
    {
        parent.InsertAfterSelf( DatasetToTable( ds ) );
        parent.Remove();
    }
    mainPart.Document.Save();
