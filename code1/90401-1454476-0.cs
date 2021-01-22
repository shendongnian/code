    foreach (FontFamily fontFamily in FontFamily.Families)
    {
        if (fontFamily.IsStyleAvailable(FontStyle.Regular))
        {
            fontComboBox.Items.Add(fontFamily.Name + " (Regular)");
        }
        if (fontFamily.IsStyleAvailable(FontStyle.Bold))
        {
            fontComboBox.Items.Add(fontFamily.Name + " (Bold)");
        }
        if (fontFamily.IsStyleAvailable(FontStyle.Italic))
        {
            fontComboBox.Items.Add(fontFamily.Name + " (Italic)");
        }
        if (fontFamily.IsStyleAvailable(FontStyle.Underline))
        {
            fontComboBox.Items.Add(fontFamily.Name + " (Underline)");
        }
        if (fontFamily.IsStyleAvailable(FontStyle.Strikeout))
        {
            fontComboBox.Items.Add(fontFamily.Name + " (Strikeout)");
        }
    }
