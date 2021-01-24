    public class Page
    {
        public string PageProperty { get; set; }
    }
    public abstract class BasePage : Page, IDisposable
    {
        public void Dispose()
        {
        }
    }
    public class ContentPage : BasePage
    {
        public string ContentProperty { get; set; }
    }
    public class TabbedPage : BasePage
    {
        public string TabbedProperty { get; set; }
    }
    public class ContentBasePage : ContentPage{}
    public class TabbedBasePage : TabbedPage{}
