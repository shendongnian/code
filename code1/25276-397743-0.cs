    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        bool cont;
        string languageCode;
        using (LangForm lang = new LangForm())
        {
            cont = lang.ShowDialog() == DialogResult.OK;
            languageCode = lang.LanguageCode; // "en-US", etc
        }
        if (!cont) return;
        Thread.CurrentThread.CurrentCulture =
            Thread.CurrentThread.CurrentUICulture =
                CultureInfo.GetCultureInfo(languageCode);
        using (MainForm main = new MainForm())
        {
            Application.Run(main);
        }
    }
