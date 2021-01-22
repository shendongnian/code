     public class Test
        {
        	Dictionary<int,string> str=new Dictionary<int,string>(); 
        	public string this[int i]
        	{
        		get
        		{
        			return str[i];
        		}
        		set
        		{
        			if(!str.ContainsKey(i))
        				str.Add(i,value);
        			else
        				str[i] = value;
        		}
        	}
