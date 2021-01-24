    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Sport();
            car.BuyEvent += License.GenerateLicense;		
            car.OnBuy();
    		car = new City();
    		car.BuyEvent += License.GenerateLicense;
    		car.OnBuy();
        }
    }
    
    internal abstract class Car
    {
        internal abstract void Name();
    
        protected abstract event EventHandler Buy;
    
    	public abstract event EventHandler BuyEvent;
    
    	public abstract void OnBuy();	
    }
    
    internal class Sport : Car
    {
    	internal override void Name()
    	{
    		Console.WriteLine("Sport Car");
    	}
    	
    	protected override event EventHandler Buy;
    	
    	public override event EventHandler BuyEvent
    	{
    		add
    		{
    			lock (this)
    			{
    				Buy += value;
    			}
    		}
    
    		remove
    		{
    			lock (this)
    			{
    				Buy -= value;
    			}
    		}
    	}
    
    	public override void OnBuy()
    	{
    		if (Buy != null)
    		{
    			Buy(this, EventArgs.Empty);
    		}
    	}
    
    }
    
    internal class City : Car
    {
    	internal override void Name()
    	{
    		Console.WriteLine("City Car");
    	}
    
    	protected override event EventHandler Buy;
    
    	public override event EventHandler BuyEvent
    	{
    		add
    		{
    			lock (this)
    			{
    				Buy += value;
    			}
    		}
    
    		remove
    		{
    			lock (this)
    			{
    				Buy -= value;
    			}
    		}
    	}
    
    	public override void OnBuy()
    	{
    		if (Buy != null)
    		{
    			Buy(this, EventArgs.Empty);
    		}
    	}
    }
    
    internal static class License
    {
    
    	public static void GenerateLicense(object sender, EventArgs args)
    	{
    		Random rnd = new Random();
    
    		string carType = sender.GetType().Name;
    
    		string licenseNumber = "";
    
    		for (int i = 0; i < 5; i++)
    		{
    			licenseNumber += rnd.Next(0, 9).ToString();
    		}
    
    		Console.WriteLine($"{carType} Car has been bought, this is the license number: {licenseNumber}");
    	}
    
    }
