    public static class DictionaryExt 
    {
        // helper method that allows compiler to provide type inference
        // when attempting to locate optionally existent items in a dictionary
        public static Tuple<TValue,bool> Find<TKey,TValue>( 
            this IDictionary<TKey,TValue> dict, TKey keyToFind ) 
        {
            TValue foundValue = default(TValue);
            bool wasFound = dict.TryGetValue( keyToFind, out foundValue );
            return Tuple.Create( foundValue, wasFound );
        }
    }
    public class Program
    {
        public static void Main()
        {
            var people = new[] { new { LastName = "Smith", FirstName = "Joe" },
                                 new { LastName = "Sanders", FirstName = "Bob" } };
       
            var peopleDict = people.ToDictionary( d => d.LastName );
            // ??? foundItem <= what type would you put here?
            // peopleDict.TryGetValue( "Smith", out ??? );
            // so instead, we use our Find() extension:
            var result = peopleDict.Find( "Smith" );
            if( result.First )
            {
                Console.WriteLine( result.Second );
            }
        }
    }
