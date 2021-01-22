    public void FillFontComboBox(ComboBox comboBoxFonts)
    {
        // Enumerate the current set of system fonts,
        // and fill the combo box with the names of the fonts.
        foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
        {
            // FontFamily.Source contains the font family name.
            comboBoxFonts.Items.Add(fontFamily.Source);
        }
    
        comboBoxFonts.SelectedIndex = 0;
    }
