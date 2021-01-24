    public interface IWebElement
    {
        void Click();
    }
    public interface IPageElement : IWebElement
    {
        void GetSomething();
    }
    public class PageElementImpl : IPageElement
    {
        public void Click()
        {
            Console.WriteLine("Click");
        }
        public void GetSomething()
        {
            Console.WriteLine("GetSomething");
        }
    }
    static void Main(string[] args)
    {
        IWebElement webElement = new PageElementImpl();
        IPageElement pageElement = new PageElementImpl();
        webElement.Click();  //Legal
        pageElement.Click();  //Legal
        webElement.GetSomething();  //Not Legal as GetSomething() is not part of IWebElment
        pageElement.GetSomething();  //Legal
    }
