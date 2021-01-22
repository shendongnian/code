    public static string[] GetInstalledCultures()
    {
        List<string> cultures = new List<string>();
        foreach (string file in Directory.GetFiles(HttpContext.Current.Server.MapPath("/App_GlobalResources"), \\Change folder to search in if needed.
            "*.resx", SearchOption.TopDirectoryOnly))
        {
            string name = file.Split('\\').Last();
            name = name.Split('.')[1];
            cultures.Add(name != "resx" ? name : "auto"); \\Change "auto" to something else like "en-US" if needed.
        }
        return cultures.ToArray();
    }
