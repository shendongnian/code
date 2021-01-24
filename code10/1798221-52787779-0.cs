    public static class Util
    {
        public static string GlobalString = "Hello World";
        public static string GetCurrentLanguage()
        {
            string SelectedLangProp;
            if (Application.Current.Properties.ContainsKey("SelectedLangProp"))
            {
                SelectedLangProp = Application.Current.Properties["SelectedLangProp"] as string;
            }
            else
            {
                SelectedLangProp = "AR";//default language
            }
            return SelectedLangProp;
        }
    }
