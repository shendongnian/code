    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MyApplication
    {
    	
    	public struct City
    	{
    		public string Name;
    		// you could also set a converter for this field specifically if you only need for specific fields but also
    		// still want it to display as a normal json object when you serialise the object.
    		// [JsonConverter(typeof(CountryConverter))]
    		public Country Country;
    	}
    
    	// Setting a json converter attribute allows json.net to understand that an object by default
    	// will be serialised and deserialised using the specified converter.
    	[JsonConverter(typeof(CountryConverter))]
    	public class Country
    	{
    		public Country(string code)
    		{
    			switch (code)
    			{
    				case "US": Name = "United-States"; break;
    				case "GB": Name = "United Kingdom"; break;
    				case "FR": Name = "France"; break;
    				case "ES": Name = "Spain"; break;
    				case "CA": Name = "Canada"; break;
    			}
    		}
    		public string Code { get; set; }
    		public string Name { get; set; }
    	}
    
    
    	public class CountryConverter : JsonConverter<Country>
    	{
    		// Assuming that the countries are serialised using the code
    		public override Country ReadJson(JsonReader reader, Type objectType, Country existingValue, bool hasExistingValue, JsonSerializer serializer)
    		{
    			if(reader.Value == null && reader.ValueType == typeof(string))
    			{
    				return null;
    			}
    
    			string code = (string) reader.Value;
    			code = code.ToUpperInvariant(); // Because reducing error points is usually a good thing
    
    			return new Country(code);
    			
    		}
    
    		public override void WriteJson(JsonWriter writer, Country value, JsonSerializer serializer)
    		{
    			//Writes the code as the value for the object
    			writer.WriteValue(value.Code);
    		}
    	}
    }
