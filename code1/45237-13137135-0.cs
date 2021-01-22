    public class BrowserHelper
    {
        private sealed class HyperlinkButtonCaller : HyperlinkButton
        {
            public static void OpenUrl(Uri url)
            {
                var button = new HyperlinkButtonCaller()
                {
                    NavigateUri = url
                };
    
                button.OnClick();
            }
        }
    
        public static void OpenUrl(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
    
            HyperlinkButtonCaller.OpenUrl(url);
        }
    }
    
    BrowserHelper.OpenUrl(new Uri(ClientGlobalInfo.Current.ApplicationUrl, "myhandler.ashx"));
