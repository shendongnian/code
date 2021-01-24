    static bool IsFontInstalled(string fontname)
    {
        using (var ifc = new InstalledFontCollection())
        {
            return ifc.Families.Any(f => f.Name == fontname);
        }
    }
