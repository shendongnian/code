    public delegate int mydelegate(string s);
    public class Test
    {
    	mydelegate MyFunc(string s)
    	{
    		return (astring => astring.Length + s.Length);
    	}
    }
