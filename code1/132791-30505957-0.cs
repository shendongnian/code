    NameValueCollection nvc = HttpContext.Current.Request.Form;
    Settings mySettingsClass = new Settings();
    foreach (string kvp in nvc.AllKeys)
    {
        PropertyInfo pi = model.GetType().GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
        if (pi != null)
        {
             pi.SetValue(model, nvc[kvp], null);
        }
    }
