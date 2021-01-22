    public IEnumerable<CultureInfo> GetSupportedCulture()
    {
        //Get all culture 
        CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.AllCultures);
        //Find the location where application installed.
        string exeLocation = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
        //Return all culture for which satellite folder found with culture code.
        return culture.Where(cultureInfo => Directory.Exists(Path.Combine(exeLocation, cultureInfo.Name)));
    }
