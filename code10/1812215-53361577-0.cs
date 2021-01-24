    public static void FillColor(Cell cell, Color color)
    {
        var w = cell.Xml.Name.Namespace;
        var shd = cell.Xml.Element(w + "tcPr").Element(w + "shd");
        shd.Attribute(w + "themeFill").Remove();
        cell.FillColor = color;
    }
