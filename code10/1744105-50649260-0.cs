    // Override language settings if needed to get the designed currency symbol
    listview.Language = System.Windows.Markup.XmlLanguage.GetLanguage("nl");
    // Add column using currency format
    gridV.Columns.Add(new GridViewColumn
    {
        Header = "Voorraden",
        Width = 100,
        DisplayMemberBinding = new Binding("Voorraden") { StringFormat = "C" }
    });
