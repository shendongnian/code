    string[] FontList = FontFamily.Families.Where(f => f.IsStyleAvailable(FontStyle.Regular)).Select(f => f.Name).ToArray();
    cboFontFamily.DrawMode = DrawMode.OwnerDrawVariable;
    cboFontFamily.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    cboFontFamily.AutoCompleteSource = AutoCompleteSource.CustomSource;
    cboFontFamily.AutoCompleteCustomSource.AddRange(FontList);
    cboFontFamily.DisplayMember = "Name";
    cboFontFamily.Items.AddRange(FontList);
    cboFontFamily.Text = "Arial";
