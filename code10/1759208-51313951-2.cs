    internal static class WebViewPageExtensions
    {
        const string ViewDataContentBlahKey = "ContentBlahKey";
        public static void SetShowContentBlah(this WebViewPage instance
           ,bool value)
        {
          instance.ViewData[ViewDataContentBlahKey] = value;
        }
        public static void GetShowContentBlah(this WebViewPage instance)
        {
          // if it's not set to false, it will be null
          var result = instance.ViewData[ViewDataContentBlahKey] as bool?;
          return result.HasValue && result.Value;
        }
    }
