            DateTime fromDate = DateTime.Parse("1/1/2009");
            DateTime toDate   = DateTime.Parse("12/31/2009");
            
            // Create an instance of the collection class
            DateTimeEnumerator dateTimeRange = 
                                  new DateTimeEnumerator( fromDate, toDate );
            // Iterate with foreach
            foreach (DateTime day in dateTimeRange )
            {
                System.Console.Write(day + " ");
            }
