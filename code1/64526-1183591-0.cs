    public static class LocalizationExtentions
    {
      public static string Localize(this HtmlHelper html, string resource)
      {
        var localize = IoC.Resolve<ILocalize>();
        return localize.For(resource);
      }
    }
