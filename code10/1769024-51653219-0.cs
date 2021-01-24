    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Data.SqlClient;
    
    namespace Rates
    {
    	public class FuelRateThing
    	{
    		public DateTime RateDate
    		{
    			get;
    			set;
    		}
    
    		public decimal FuelRate
    		{
    			get;
    			set;
    		}
    
    		public string FuelName
    		{
    			get;
    			set;
    		}
    
    		public FuelRateThing()
    		{
    		}
    
    		public FuelRateThing(DateTime date, decimal rate, string name)
    		{
    			RateDate = date;
    			FuelRate = rate;
    			FuelName = name;
    		}
    	}
    
    	public class Ratethings
    	{
    		public void dostuff()
    		{
    			CultureInfo provider = CultureInfo.InvariantCulture;
    			//Create a class to manage these objects perhaps, here is a simple list example.
    			// populate your list - normally parse and validation of UI values:
    			List<FuelRateThing> monthRatesList = new List<FuelRateThing>()
    			{new FuelRateThing{RateDate = DateTime.ParseExact("20180101", "yyyyMMdd", provider), FuelRate = 3.45m, FuelName = "kerosene"}, new FuelRateThing{RateDate = DateTime.ParseExact("20180102", "yyyyMMdd", provider), FuelRate = 3.49m, FuelName = "kerosene"}, new FuelRateThing{RateDate = DateTime.ParseExact("20180103", "yyyyMMdd", provider), FuelRate = 3.48m, FuelName = "kerosene"}, new FuelRateThing{RateDate = DateTime.ParseExact("20180104", "yyyyMMdd", provider), FuelRate = 3.65m, FuelName = "kerosene"}, new FuelRateThing{RateDate = DateTime.ParseExact("20180105", "yyyyMMdd", provider), FuelRate = 3.60m, FuelName = "kerosene"}, };
    			// add a couple more rows
    			monthRatesList.Add(new FuelRateThing(DateTime.ParseExact("20180106", "yyyyMMdd", provider), 3.64m, "kerosene"));
    			var newrate = new FuelRateThing{RateDate = DateTime.ParseExact("20180107", "yyyyMMdd", provider), FuelRate = 3.47m, FuelName = "kerosene"};
    			monthRatesList.Add(newrate);
    		}
    
    		//Now use the data access code to insert those: (probably in a method that accepts a list of `FuelRateThings`:
    		public class DataStore
    		{
    			public void SaveRateThings(List<FuelRateThing> rateList)
    			{
    				var _connectionSB = new SqlConnectionStringBuilder();
    				// do connections string stuff here
    				var _connectionString = _connectionSB.ToString();
    				using (SqlConnection connection = new SqlConnection(_connectionString))
    				{
    					String query = @"
               INSERT INTO TripSheet (DateColumnName,FuelColumnName,RateColumnName)
               VALUES (@DateColumnName,@FuelColumnName,@RateColumnName)";
    					using (SqlCommand command = new SqlCommand(query, connection))
    					{
    						connection.Open();
    						foreach (FuelRateThing rate in rateList)
    						{
    							command.Parameters.AddWithValue("@DateColumnName", rate.RateDate);
    							command.Parameters.AddWithValue("@FuelColumnName", rate.FuelName);
    							command.Parameters.AddWithValue("@RateColumnName", rate.FuelRate);
    							int result = command.ExecuteNonQuery();
    						}
    					}
    				}
    			}
    		}
    	}
    }
