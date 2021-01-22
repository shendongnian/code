    public List<CultureInfo> GetSupportedCultures()
    {
        CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.AllCultures);
    
        // get the assembly
        Assembly assembly = Assembly.GetExecutingAssembly();
    
        //Find the location of the assembly
        string assemblyLocation =
            Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(assembly.CodeBase).Path));
    
        //Find the file anme of the assembly
        string resourceFilename = Path.GetFileNameWithoutExtension(assembly.Location) + ".resources.dll";
    
        //Return all culture for which satellite folder found with culture code.
        return culture.Where(cultureInfo =>
            assemblyLocation != null &&
            Directory.Exists(Path.Combine(assemblyLocation, cultureInfo.Name)) &&
            File.Exists(Path.Combine(assemblyLocation, cultureInfo.Name, resourceFilename))
        ).ToList();
    }
