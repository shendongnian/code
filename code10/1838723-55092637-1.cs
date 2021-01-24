    SwatchesProvider swatchesProvider = new SwatchesProvider();
    List<string> PrimaryColorsList = swatchesProvider.Swatches.Select(a => a.Name).ToList();
    this.primaryPaletteComboBox.Items.AddRange(PrimaryColorsList);
    private void primaryPaletteComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        SwatchesProvider swatchesProvider = new SwatchesProvider();
        Swatch color= swatchesProvider.Swatches.FirstOrDefault(a => a.Name == this.primaryPaletteComboBox.Text);
        paletteHelper.ReplacePrimaryColor(color);
    }
