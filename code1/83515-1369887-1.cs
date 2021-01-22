    public static string GetDescription(this System.Enum value)
    {
        string enumID = string.Empty;
        string enumDesc = string.Empty;
        try 
        {         
            // try to lookup Description attribute
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attribs.Length > 0)
            {
                enumID = ((DescriptionAttribute)attribs[0]).Description;
                enumDesc = TranslationHelper.GetTranslation(enumID);
            }
            if (string.IsNullOrEmpty(enumID) || TranslationHelper.IsTranslationMissing(enumDesc))
            {
                // try to lookup translation from EnumName_EnumValue
                string[] enumName = value.GetType().ToString().Split('.');
                enumID = string.Format("{0}_{1}", enumName[enumName.Length - 1], value.ToString());
                enumDesc = TranslationHelper.GetTranslation(enumID);
                if (TranslationHelper.IsTranslationMissing(enumDesc))
                    enumDesc = string.Empty;
            }
            // try to format CamelCase to proper names
            if (string.IsNullOrEmpty(enumDesc))
            {
                Regex capitalLetterMatch = new Regex("\\B[A-Z]", RegexOptions.Compiled);
                enumDesc = capitalLetterMatch.Replace(value.ToString(), " $&");
            }
        }
        catch (Exception)
        {
            // if any error, fallback to string value
            enumDesc = value.ToString();
        }
        return enumDesc;
    }
