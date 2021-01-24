    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string msg = "{Type=\"wednesday report\", corporate=\"ubl\", reg#=\"BNN - 527\", Driven=\"304.5Km\", MaxSpeed=\"150km / hr\", IgnitionsON=\"5\", Stopped=\"21.8hrs\", Running=\"1.7hrs\", Idle=\"0.5hrs\", image=\"varbinary data from db\", link=\"http://iteck.pk/d/pXhAo\"}";
    		string result = betweenStrings(msg,"Type=\"","\",");
    		Console.WriteLine(result);
    	}
    	
    	public static String betweenStrings(String text, String start, String end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);
    
            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);                      
        }
    }
