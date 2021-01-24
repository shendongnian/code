    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"
    			{
    			   ""Code"":1,
    			   ""Message"":""OK"",
    			   ""Data"": {""Name"": ""Patrick"", ""Email"": ""aa@aaa.com"", ""Age"" : 25}
    			}";
    		
    		Console.WriteLine(json);
    		
    		var response=json.ToWrapper<Person>();
    		
    		Console.WriteLine("Name: "+response.Data.Name);
    		Console.WriteLine("Email: "+response.Data.Email);
    		Console.WriteLine("Age: "+response.Data.Age);
    	}
    }
    
    public class Person{
    	public string Name {get;set;}
    	public string Email {get;set;}
    	public int Age {get;set;}
    }
    
    public class Response<T>{
    	public int Code {get;set;}
    	public string Message {get;set;}
    	public T Data {get;set;}
    }
    
    public static class ResponseExtensions {
    	public static Response<T> ToWrapper<T>(this string json){
    		
    		var o=JObject.Parse(json);
    		var data=JsonConvert.DeserializeObject<T>(o["Data"].ToString());
    		
    		return new Response<T>{
    			Code=(int)o["Code"],
    			Message=(string)o["Message"],
    			Data=data
    		};
    	}
    }
