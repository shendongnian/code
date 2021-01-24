    void Main()
    {
    	var sl = new SellerLogin(new WebDriver());
    
    	Console.WriteLine(SellerLogin.Driver != null);
    }
    
    public abstract class PageObjectBase
    {
    	public static IWebDriver Driver { get; set; }
    
    	protected PageObjectBase(IWebDriver driver)
    	{
    		Driver = driver;
    	}
    }
    
    public class SellerLogin : PageObjectBase
    {
    	public SellerLogin(IWebDriver driver) : base(driver) { }
    }
    
    public interface IWebDriver { }
    
    public class WebDriver : IWebDriver { }
