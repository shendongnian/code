    using System;
    using System.Text.RegularExpressions;					
    public class Program
    {
    	public static void Main()
    	{
    		string msg = "{Type=\"wednesday report\", corporate=\"ubl\", reg#=\"BNN - 527\", Driven=\"304.5Km\", MaxSpeed=\"150km / hr\", IgnitionsON=\"5\", Stopped=\"21.8hrs\", Running=\"1.7hrs\", Idle=\"0.5hrs\", image=\"varbinary data from db\", link=\"http://iteck.pk/d/pXhAo\"}";
    		Match match = Regex.Match(msg, "Type=\"(.*?)\",");
    
            if (match.Success)
            {
                string key = match.Groups[1].Value;
                Console.WriteLine(key);
            }
    	}
    }
