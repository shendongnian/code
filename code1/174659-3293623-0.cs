    public interface ICar
    {
    	bool IsAutomatic();
    }
    
    public class Silverado : ICar
    {
    	public bool IsAutomatic()
    	{
    		return true;
    	}
    }
    
    public class Semi : ICar
    {
    	public bool IsAutomatic()
    	{
    		return false;
    	}
    }
    
    void Main()
    {
    	ICar car = new Silverado();
    	bool isAuto = car.IsAutomatic();
    	isAuto.Dump();
    
    	car = new Semi();
    	isAuto = car.IsAutomatic();
    	isAuto.Dump();
    }
