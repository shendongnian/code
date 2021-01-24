    public static async Task<T> LoadJsonFile<T>(this Assembly assembly, string fullFilename)
        where T : new()
    {
        using (var stream = assembly.GetManifestResourceStream(fullFilename))
        {
            using (var reader = new StreamReader(stream))
            {
                string json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
