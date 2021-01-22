    class Program
    {        
        public class Person
        {
            public string Name;
            public int Age;
        }        
        public static void ExecuteQueryAsync ( IEnumerable<Person> collectionToQuery , Action<List<Person>> onQueryTerminated , out Action stopExecutionOfQuery )
        {
            var abort = false;
            stopExecutionOfQuery = () =>
            {
                abort = true;
            };            
            Task.Factory.StartNew( () =>
            {
                try
                {
                    var query = collectionToQuery.Where( x =>
                    {
                        if ( abort )
                            throw new NotImplementedException( "Query aborted" );
                        // query logic:
                        if ( x.Age < 25 )
                            return true;
                        return
                            false;
                    } );
                    onQueryTerminated( query.ToList() );
                }
                catch
                {
                    onQueryTerminated( null );
                }
            });
        }
        static void Main ( string[] args )
        {
            Random random = new Random();
            Person[] people = new Person[ 1000000 ];
            // populate array
            for ( var i = 0 ; i < people.Length ; i++ )
                people[ i ] = new Person() { Age = random.Next( 0 , 100 ) };
            Action abortQuery;
            ExecuteQueryAsync( people , OnQueryDone , out abortQuery );
            // if after some time user wants to stop query:
            abortQuery();
            Console.Read();
        }
        static void OnQueryDone ( List<Person> results )
        {
            if ( results == null )
                Console.WriteLine( "Query was canceled by the user" );
            else
                Console.WriteLine( "Query yield " + results.Count + " results" );
        }
    }
