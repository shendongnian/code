    public static Dictionary<string, string> GetSendGridTemplates()
    {
        var templatesRaw = Persistent.ConfiguredSendGridClient.RequestAsync(SendGridClient.Method.GET, null, null, "templates").Result;
        var templates = templatesRaw.DeserializeResponseBody(templatesRaw.Body);
        var templatesEnumerable = ((IEnumerable)templates.First().Value).Cast<dynamic>();
        var results = new Dictionary<string, string>();
        foreach (dynamic template in templatesEnumerable)
        {
            var activeVersion = ((IEnumerable)template.versions).Cast<dynamic>().Where(v => v.active).SingleOrDefault();
            if (activeVersion == null)
                continue; //skip this one
            results.Add((string)activeVersion.name, (string)template.id);
        }
        return results;
    }
