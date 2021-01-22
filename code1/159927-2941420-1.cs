    public static class Translate
    
    {
    
        public static string GetLanguage()
    
        {
    
            return HttpContext.Current.Request.UserLanguages[0];
    
        }
    
     
    
        public static string Message(string key)
    
        {
    
            ResourceManager resMan = null;
    
            if (HttpContext.Current.Cache["resMan" + Global.GetLanguage()] == null)
    
            {
    
                resMan = Language.GetResourceManager(Global.GetLanguage());
    
                if (resMan != null) HttpContext.Current.Cache["resMan" + Global.GetLanguage()] = resMan;
    
            }
    
            else
    
                resMan = (ResourceManager)HttpContext.Current.Cache["resMan" + Global.GetLanguage()];
    
     
    
            if (resMan == null) return key;
    
     
    
            string originalKey = key;
    
            key = Regex.Replace(key, "[ ./]", "_");
    
     
    
            try
    
            {
    
                string value = resMan.GetString(key);
    
                if (value != null) return value;
    
                return originalKey;
    
            }
    
            catch (MissingManifestResourceException)
    
            {
    
                try
    
                {
    
                    return HttpContext.GetGlobalResourceObject("en_au", key).ToString();
    
                }
    
                catch (MissingManifestResourceException mmre)
    
                {
    
                    throw new System.IO.FileNotFoundException("Could not locate the en_au.resx resource file. This is the default language pack, and needs to exist within the Resources project.", mmre);
    
                }
    
                catch (NullReferenceException)
    
                {
    
                    return originalKey;
    
                }
    
            }
    
            catch (NullReferenceException)
    
            {
    
                return originalKey;
    
            }
    
        }
    
    }
