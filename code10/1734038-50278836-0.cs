    public class Program
    {
    	public static void Main()
    	{
    		Child1.SortList(new List<Child1>() {});
    	}
    }
    
    public class Parent
    {
    	public static List<Parent> SortList(IEnumerable<Parent> liste)
    	{
    		return null;
    	}
    }
    
    public class Child1 : Parent
    {
    }
