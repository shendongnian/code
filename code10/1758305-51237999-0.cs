    public interface IPlatform
    {
        void Login<T>(T model);
    }
    public class Desktop : IPlatform
    {
        private readonly WebDriver _webDriver;
        public Desktop(WebDriver driver)
        {
            _webDriver = driver;
        }
        public void Login<T>(T model)
        {
            // do login here
        }
    }
    // usage
    IPlatform desktop = new Desktop(/*chromedriver*/); // or inject
    desktop.Login<AccountModel>(model);
