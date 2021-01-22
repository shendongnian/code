    const int numColumns = 3;
    const int numColumns = 3;
    var columnLength = (int)Math.Ceiling((double)myItemCollection.Count / 3);
    
    for (int i = 0; i < myItemCollection.Count; i++)
    {
        if (i % columnLength == 0)
        {
            if (i > 0)
                Response.Write("</ul>");
            Response.Write("<ul>");
        }
        Response.Write(myItemCollection[i].SomeProperty);
    }
    if (i % columnLength == 0)
        Response.Write("</ul>");
