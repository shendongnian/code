    public class UrlEnums
    {
        public enum Url
        {
            [Description("https://www.companysite1.com")] 
            company1,
            [Description("https://www.companysite2.com")] 
            company2
        }
    }
    
    public void NavigateTo(UrlEnums.Url url)
    {
        
         Driver.Navigate().GoToUrl(GetEnumDescription(url));
    }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);
            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
