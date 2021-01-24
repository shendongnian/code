    using System;
    using System.Collections.Generic;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                // A reference to IEnumerable<T>
                // Behaves much like a function when used in a loop.
                var items = GetItems<object>();
    
                // For each works on IEnumerable types and internally calls the GetEnumerator() method.
                // GetEnumerator() returns IEnumerator<T> which has 1 property and 2 methods :: Current, MoveNext(), and Reset()
                // It basically calls GetEnumerator() and then MoveNext() and Current to give us the results
                foreach (var item in items)
                    Console.WriteLine(item);
    
                //Here's an example of the loop above written manually just to help you visualize it.
                var enumerator = items.GetEnumerator();
                while (enumerator.MoveNext())
                    Console.WriteLine(enumerator.Current);
    
                //Finally; we can't write syntax but here's a method (seen below) that's much like the foreach syntax.
                ForEach(items, item => Console.WriteLine(item));
    
                Console.Read();
            }
    
            static void ForEach<T>(IEnumerable<T> items, Action<T> action)
            {
                IEnumerator<T> enumerator = items.GetEnumerator(); 
                iterateItems();
                
                void iterateItems()
                {
                    // Notice that it's not actually until we get HERE calling MoveNext() that the yield return Activator.CreateInstance<T>() is actually called in our application.
                    // And even now we don't have a reference to it ourselves; it's just placed into the Current property of the IEnumerator<T> type.
                    var hasAnotherItem = enumerator.MoveNext();
                    if (hasAnotherItem)
                    {
                        // HERE is where we finally gain our own reference to the instantiated object for this example.
                        T currentItem = enumerator.Current;
                        action.Invoke(currentItem);
                        iterateItems();
                    }
                }
            }
    
            static IEnumerable<T> GetItems<T>()
            {
                yield return Activator.CreateInstance<T>();
            }
        }
        // Outputs: 
        // System.Object
    }
