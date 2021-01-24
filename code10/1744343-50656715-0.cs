    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class TestClass
    {
    	public int Id {get; set;}
    	public DateTime Date {get; set;}
    	
    	public override string ToString()
    	{
    		return string.Format("Id : {0} Date : {1}", this.Id, this.Date);
    	}
    }
    					
    public class Program
    {
    	public static void Main()
    	{
    		var jsonString = "[{\"id\":1, \"date\":\"03/21/2018 11:08AM GMT\"}, {\"id\":2, \"date\":\"03/18/2018 11:08AM GMT+1\"}, {\"id\":3, \"date\":\"03/15/2018 11:08AM GMT+10\"}]";
    		var list = JsonConvert.DeserializeObject<List<TestClass>>(jsonString, new JsonSerializerSettings() { DateFormatString  = "MM/dd/yyyy hh:mmtt \"GMT\"z"});
    		
    		list.ForEach((item) => Console.WriteLine(item));
    	}
    }
