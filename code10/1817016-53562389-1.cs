    class Ppal {
        public static void Main()    
        {
                var foo = new Foo{ A = 5, B = 6 };
    
                foreach(KeyValuePair<string, object> pair in GetAllProperties( foo ) ) {
                    Console.WriteLine( "Foo.{0} = {1}", pair.Key, pair.Value );
                }
        }
    }
