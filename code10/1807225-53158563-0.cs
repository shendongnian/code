    public static class LanguageExtensions
    {
        public static RouteValueDictionary ForLang(this RouteValueDictionary dict, string lang)
        {
            var cloned = new RouteValueDictionary(dict);
            cloned["lang"] = lang;
            return cloned;
        }
    }
