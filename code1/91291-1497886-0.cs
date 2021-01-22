        public override string ToString()
        {
            string localizedName = fontFamily.FamilyNames[XmlLanguage.GetLanguage(CultureInfo.CurrentUICulture.Name)];
            if (!String.IsNullOrEmpty(localizedName))
                return localizedName;
            return fontFamily.ToString();
        }
