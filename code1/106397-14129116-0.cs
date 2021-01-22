    static void Main()
        {
            /* 
            "AsEnumerable" purpose is to cast an IQueryable<T> sequence to IEnumerable<T>, 
            forcing the remainder of the query to execute locally instead of on database as below example so it can hurt performance.  (bind  Enumerable operators instead of Queryable). 
              
            In below example we have cars table in SQL Server and are going to filter red cars and filter equipment with some regex:
            */
            Regex wordCounter = new Regex(@"\w");
            var query = dataContext.Cars.Where(car=> article.Color == "red" && wordCounter.Matches(car.Equipment).Count < 10);
    
            /* 
            SQL Server doesn’t support regular expressions  therefore the LINQ-to-db  providers  will  throw  an  exception: query  cannot  be translated to SQL.
            
            TO solve this firstly we can get all cars with red color using a LINQ to SQL query, 
            and secondly filtering locally for Equipment of less than 10 words:
            */
    
            Regex wordCounter = new Regex(@"\w");
    
            IEnumerable<Car> sqlQuery = dataContext.Cars
              .Where(car => car.Color == "red");
            IEnumerable<Car> localQuery = sqlQuery
              .Where(car => wordCounter.Matches(car.Equipment).Count < 10);
    
            /*
            Because sqlQuery is of type IEnumerable<Car>, the second query binds  to the local query operators,
            therefore that part of the filtering is run on the client.
            
            With AsEnumerable, we can do the same in a single query:
            
             */
            Regex wordCounter = new Regex(@"\w"); 
            var query = dataContext.Cars
              .Where(car => car.Color == "red")
              .AsEnumerable()
              .Where(car => wordCounter.Matches(car.Equipment).Count < 10);
    
            /*
            An alternative to calling AsEnumerable is ToArray or ToList.
            */
        }
