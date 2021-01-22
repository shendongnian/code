    public class Foo
    {
        public class FooSpecificCollection : List<Bar>
        {
             private FooSpecificCollection ()   { }
    
             public static FooSpecificCollection GetFoosStuff()
             {
                var collection = new FooSpecificCollection ();
                PrepareFooSpecificCollection(collection);
                return collection;            
             }
        }
    
        private static void PrepareFooSpecificCollection(FooSpecificCollection collection)
        {
             //prepare the collection
        }
    }
