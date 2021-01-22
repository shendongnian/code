        internal static string GetString(string str, string lang)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentNullException("empty language query string");
            if (string.IsNullOrEmpty(lang)) throw new ArgumentNullException("no language resource given");
            // culture-specific file, i.e. "PIAE.LangResources.fr"
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PIAE.LangResources."+lang);
            // resource not found, revert to default resource
            if (null == stream)
            {                                                                   
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PIAE.Properties.LangResources.resources");
            }
            ResourceReader reader = new ResourceReader(stream);
            IDictionaryEnumerator en= reader.GetEnumerator();
            while (en.MoveNext())
            {
                if (en.Key.Equals(str))
                {
                    return en.Value.ToString();
                }
            }
            // string not translated, revert to default resource
            return LangResources.ResourceManager.GetString(str);
        }
