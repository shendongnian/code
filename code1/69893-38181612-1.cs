    public string GetStringFromDynamicResourceFile(string resxFileName, string resource)
    {
        return XDocument
                    .Load(resxFileName)
                    .Descendants()
                    .FirstOrDefault(_ => _.Attributes().Any(a => a.Value == resource))?
                    .Value;
    }
