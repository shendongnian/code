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
    		public Country Country;
    	}
    
    	// Using the full name as it makes it easier to work with and also because you'd need a json converter
    	// if you want a string and not the number/index of the country when you serialise the data
    	[JsonConverter(typeof(CountryConverter))]
    	public enum Country
    	{
    		UnitedStates,
    		UnitedKingdom,
    		France,
    		Spain,
    		Canada
    	}
    
    	// this class only exists for you to add extentions to this enums.
    	// In short extentions are a type of methods added to other classes that act
    	// as if they were part of outher classes. usually this means that the first parameter
    	// is prefixed by this.
    	public static class CountryExtentions
    	{
    		public static string GetCode(this Country country)
    		{
    			switch (country)
    			{
    				case Country.UnitedStates: return "US";
    				case Country.UnitedKingdom: return "GB";
    				case Country.France: return "FR";
    				case Country.Spain: return "SP";
    				case Country.Canada: return "CA";
    				default: throw new InvalidOperationException($"This country has no code {country.ToString()}");
    			}
    		}
    	}
    	public class CountryConverter : JsonConverter<Country>
    	{
    		// Assuming that the countries are serialised using the code
    		public override Country ReadJson(JsonReader reader, Type objectType, Country existingValue, bool hasExistingValue, JsonSerializer serializer)
    		{
    			// make sure you can convert the thing into a string
    			if (reader.Value == null && reader.ValueType == typeof(string))
    			{
    				throw new InvalidOperationException($"The data type passed {reader.ValueType.Name} isn't convertible. The data type musts be a string.");
    			}
    
    			// get the value
    			string code = (string)reader.Value;
    			code = code.ToUpperInvariant(); // Because reducing error points is usually a good thing
    
    			// cycle through the enum values to compare them to the code
    			foreach (Country country in Enum.GetValues(typeof(Country)))
    			{
    				// if the code matches
    				if (country.GetCode() == code)
    				{
    					// return the country enum
    					return country;
    				}
    			}
    			// if no match is found, the code is invlalid
    			throw new InvalidCastException("The provided code could not be converted.");
    
    		}
    
    		public override void WriteJson(JsonWriter writer, Country value, JsonSerializer serializer)
    		{
    			//Writes the code as the value for the object
    			writer.WriteValue(value.GetCode());
    		}
    	}
    }
