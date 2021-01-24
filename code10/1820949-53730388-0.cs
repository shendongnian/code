    Word.Shape shp = ActiveDocument.Shapes[1];
    Word.Adjustments = adj = shp.Adjustments;
    for (int p = 1; p<=adj.Count; p++)
    {
        Debug.Print(adj.Item[p].ToString());
    }
