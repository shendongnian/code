    public CultureInfo defaultLanguage;
    public CultureInfo ci;
    private void cbbLanguage_DropDownClosed(object sender, EventArgs e)
    {
        int iLcid = Int32.Parse(_lstLanguages[this.cbbLanguage.SelectedIndex].LanguageId);
        ci = new System.Globalization.CultureInfo(iLcid);
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        CultureInfo ci2 = CultureInfo.CreateSpecificCulture(ci.Name);
        //InputLanguageManager.SetInputLanguage(this.rtbDoc, CultureInfo.CreateSpecificCulture(ci2.Name));
        XmlLanguage xl = this.rtbDoc.Document.Language;
        XmlLanguage xl2 = XmlLanguage.GetLanguage(ci2.IetfLanguageTag);
        // this works in changing the property but nothing changes in the doc
        this.rtbDoc.Language = xl2;  
        if (this.rtbDoc.Selection.Text.Length > 1)
        {
            // this works to change the property and the spellchecker shows the entire 
            // doc content misspelled, but the selected text remains english
            this.rtbDoc.Selection.ApplyPropertyValue(FrameworkElement.LanguageProperty, xl2);  
        }
    }
    private void ChangeLanguage(object sender, RoutedEventArgs e)
        {
            defaultLanguage = InputLanguageManager.Current.CurrentInputLanguage;
            InputLanguageManager.Current.CurrentInputLanguage = CultureInfo.CreateSpecificCulture(ci.Name);
        }
    private void ChangeToDefault(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.Current.CurrentInputLanguage = defaultLanguage;
        
