    public IEnumerable<CultureInfo> GetSupportedCulture()
    {
        CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.AllCultures);
        
        string exeLocation = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
        return culture.Where(cultureInfo => Directory.Exists(Path.Combine(exeLocation, cultureInfo.Name)));
    }
