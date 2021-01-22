    using System;
    using System.Data.SqlClient;
    
    namespace NullableTypes
    {
    	class Program
    	{
    		static class Constants
    		{
    			public static decimal NullDecimal
    			{
    				get { return decimal.MinValue; }
    			}
    		}
    
    		public class ProductTheOldWay
    		{
    			public string Name { get; set; }
    			public decimal UnitPrice { get; set; }
    
    			public ProductTheOldWay()
    			{
    				Name = string.Empty;
    				UnitPrice = Constants.NullDecimal;
    			}
    
    			public override string ToString()
    			{
    				return "Product: " + Name + " Price: " + ((UnitPrice == Constants.NullDecimal) ? "Out of stock" : UnitPrice.ToString());
    			}
    
    			public void Save()
    			{
    				//Datalayer calls and other props omitted
    				var sqlParm = new SqlParameter
    				{
    					Value = (UnitPrice == Constants.NullDecimal) ? DBNull.Value : (object)UnitPrice
    				};
    
    				//save to the database...
    				Console.WriteLine("Value written to the database: " + sqlParm.Value);
    			}
    		}
    
    		public class ProductTheNewWay
    		{
    			public string Name { get; set; }
    			public decimal? UnitPrice { get; set; }
    
    			public ProductTheNewWay()
    			{
    				Name = string.Empty;
    			}
    
    			public override string ToString()
    			{
    				return "Product: " + Name + " Price: " + ((UnitPrice.HasValue) ? UnitPrice.ToString() : "Out of stock");
    			}
    
    			public void Save()
    			{
    				//Datalayer calls and other props omitted
    				var sqlParm = new SqlParameter
    				{
    					Value = UnitPrice
    				};
    
    				//save to the database...
    				Console.WriteLine("Value written to the database: " + sqlParm.Value);
    			}
    		}
    
    		static void Main()
    		{
    			var oldProduct1 = new ProductTheOldWay
    			{
    				Name = "Widget",
    				UnitPrice = 5.99M
    			};
    
    			var oldProduct2 = new ProductTheOldWay
    			{
    				Name = "Rare Widget",
    				UnitPrice = Constants.NullDecimal // out of stock
    			};
    
    			Console.WriteLine(oldProduct1);
    			Console.WriteLine(oldProduct2);
    
    			Console.WriteLine("Saving...");
    			oldProduct1.Save();
    			oldProduct2.Save();
    
    			Console.ReadLine();
    
    			var newProduct1 = new ProductTheNewWay
    			{
    				Name = "Widget",
    				UnitPrice = 5.99M
    			};
    
    			var newProduct2 = new ProductTheNewWay
    			{
    				Name = "Rare Widget"
    				/* UnitPrice = null by default */
    			};
    
    			Console.WriteLine(newProduct1);
    			Console.WriteLine(newProduct2);
    
    			Console.WriteLine("Saving...");
    			newProduct1.Save();
    			newProduct2.Save();
    
    			Console.ReadLine();
    
    			// as a further example of the new property usage..
    
    			if (newProduct1.UnitPrice > 5)
    				Console.WriteLine(newProduct1);
    
    			Console.WriteLine("Using nullable data types is a great way to simplify code...");
    
    			Console.ReadLine();
    
    		}
    	}
    }
