         string value = "June";
         DateTime result;
         bool ok;
         ok = DateTime.TryParseExact(value, "MMMM",
                        CultureInfo.CurrentCulture, DateTimeStyles.None, out result);
         if ( ok )
         {
            int monthNumber = result.Month;
            Console.WriteLine(monthNumber);
         }
