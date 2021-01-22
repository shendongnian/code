    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false, Inherited=true)]
    public class LocalisedEnum : Attribute
    {
        public string LocalisationKey{get;set;}
        public LocalisedEnum(string localisationKey)
        {
            LocalisationKey = localisationKey;
        }
    }
    public static class LocalisedEnumExtensions
    {
        public static string ToLocalisedString(this Enum enumType)
        {
            // default value is the ToString();
            string description = enumType.ToString();
            try
            {
                bool done = false;
                MemberInfo[] memberInfo = enumType.GetType().GetMember(enumType.ToString());
                if (memberInfo != null && memberInfo.Length > 0)
                {
                    object[] attributes = memberInfo[0].GetCustomAttributes(typeof(LocalisedEnum), false);
                    if (attributes != null && attributes.Length > 0)
                    {
                        LocalisedEnum descriptionAttribute = attributes[0] as LocalisedEnum;
                        if (description != null && descriptionAttribute != null)
                        {
                            string desc = TranslationHelper.GetTranslation(descriptionAttribute.LocalisationKey);
                            if (desc != null)
                            {
                                description = desc;
                                done = true;
                            }
                        }
                    }
                }
                if (!done)
                {
                    Regex capitalLetterMatch = new Regex("\\B[A-Z]", RegexOptions.Compiled);
                    description = capitalLetterMatch.Replace(enumType.ToString(), " $&");
                }
            }
            catch
            {
                description = enumType.ToString();
            }
            return description;
        }
    }
