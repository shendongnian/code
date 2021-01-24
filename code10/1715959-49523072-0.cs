    public enum UrlEnum
    {
        [Description("https://www.companysite1.com")]
        company1,
        [Description("https://www.companysite2.com")]
        company2
    }
    public static void NavigateTo(UrlEnum url)
    {
        MemberInfo info = typeof(UrlEnum).GetMember(url.ToString()).First();
        DescriptionAttribute description = info.GetCustomAttribute<DescriptionAttribute>();
        if (description != null)
        {
            //do something like
            Driver.Navigate().GoToUrl(description.Description);
        }
        else
        {
            //do something
        }
    }
