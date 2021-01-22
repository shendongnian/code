    		DateTime dt;
			System.Globalization.CultureInfo enUS = new System.Globalization.CultureInfo("en-US"); 
			if ( DateTime.TryParseExact( "Tue Jan 20 20:47:43 GMT 2009", "ddd MMM dd H:mm:ss \"GMT\" yyyy", enUS, System.Globalization.DateTimeStyles.NoCurrentDateDefault , out dt  ))
			{
				Console.WriteLine(dt.ToString() );
			}
