    private void ChangeLanguage(string lang)
    {
        var rm = new ComponentResourceManager(this.GetType());
        var culture = CultureInfo.CreateSpecificCulture(lang);
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;
        foreach (Control c in this.AllControls())
        {
            if (c is ToolStrip)
            {
                var items = ((ToolStrip)c).AllItems().ToList();
                foreach (var item in items)
                    rm.ApplyResources(item, item.Name);
            }
            rm.ApplyResources(c, c.Name);
        }
    }
