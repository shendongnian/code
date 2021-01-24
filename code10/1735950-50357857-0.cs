    while (doc.InlineShapes.Count > 0)
    {
        doc.InlineShapes(1).Delete();  //Collection is 1-based, first element is 1, not 0; at least when using it within VBA (weird language...)
    
    }
    // and with Shapes as well
    while (doc.Shapes.Count > 0)
    {
        doc.Shapes(1).Delete();
    }
    string text = doc.Content.Text;
