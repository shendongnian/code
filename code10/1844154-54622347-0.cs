    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	private static readonly string Token = "ocean";
    	private static readonly string AppendToken = "water";
    	public static void Main()
    	{
    		var mylist = new List<string>(new string[] { "firststring", "asdsadsaoceansadsadas", "onemoreocean", "notOcccean" });
    		var newList = mylist.Select(str => {
    			if(str.Contains(Program.Token)) {
    				return str + " " +Program.AppendToken;
    			}
    			return str;
    		});
    		foreach (object o in newList)
    		{
    			Console.WriteLine(o);
    		}
    	}
    }
