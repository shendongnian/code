        interface IBar {
            IEnumerator<string> GetEnumerator();
        }
    
        class Foo : IBar {
            
            // default iterator
            public IEnumerator<int> GetEnumerator()
            {
                yield return 1;
            }
            
            // explicitly implemented interface
            IEnumerator<string> IBar.GetEnumerator()
            {
                yield return "hello";
            }
            
            // more iterators 
            public IEnumerable<string> AnotherIterator()
            {
                yield return "hello2";
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var foo = new Foo(); 
    
                foreach (int number in foo)
                {
                    Console.WriteLine(number);
                }
                 
                // notice the cast, this is non-intuitive and risky
                // I would strongly recommend against this approach
                foreach (string str in (IBar)foo)
                {
                    Console.WriteLine(str);
                }
                
                // this and the linq approach are the proper way
                foreach (string str in foo.AnotherIterator())
                {
                    Console.WriteLine(str);
                }
    
    
                Console.ReadKey();
            }
        }
    
