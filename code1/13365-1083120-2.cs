    public static CultureInfo[] GetInstalledCultures()
    {
        List<CultureInfo> cultures = new List<CultureInfo>();
        foreach (string file in Directory.GetFiles(HttpContext.Current.Server.MapPath("/App_GlobalResources"), "*.resx", SearchOption.TopDirectoryOnly))
        {
            string name = file.Split('\\').Last();
            name = name.Split('.')[1];
         string culture = name != "resx" ? name : "en-US";
         cultures.Add(new CultureInfo(culture));
        }
        return cultures.ToArray();
    }
