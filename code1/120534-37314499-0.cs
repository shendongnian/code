    //change input language to English
    InputLanguage currentLang = InputLanguage.CurrentInputLanguage;
    InputLanguage newLang = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
    if (newLang == null)
    {
        MessageBox.Show("The Upload Project function requires the En-US keyboard installed.", "Missing keyboard", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
    }
    else
    {
        InputLanguage.CurrentInputLanguage = newLang;
    }
