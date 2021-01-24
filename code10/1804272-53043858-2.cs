    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		var json = "[{ \"response\" : { \"test\" : \"Value1\" } }, { \"response\" : [ { \"test\" : \"Value2\" }, { \"test\" : \"Value3\" }] }]";
    		var items = JsonConvert.DeserializeObject<List<Item>>(json);
    		
    		foreach(var item in items)
    		{
    			var responses = item.response;
    			
    			Console.WriteLine("ResponseCount: " + responses.Count);
    			
    			foreach(var response in responses)
    			{
    				Console.WriteLine("response: " + response.test);
    			}
    		}
    	}
    }
    
    public class Item
    {
    	[JsonConverter(typeof(SingleOrArrayConverter<Data>))]
    	public List<Data> response { get;set; }
    }
    
    public class Data
    {
    	public string test { get;set; }
    }
    
    class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            return new List<T> { token.ToObject<T>() };
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
