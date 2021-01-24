        static void Main()
        {            
            IEnumerable<int> ienum = GetNumber(50, 110);
            //below line will not execute if use GetNumberByLocalMethod
            Console.WriteLine("Retrieved enumerator...");
            foreach (var i in ienum)
            {
                Console.Write($"{i} ");
            }
        }
        public static IEnumerable<int> GetNumberByLocalMethod(int start, int end)
        {
            throw new Exception("deliberately exception");
            return InnerGetNumberByLocalMethod();
            IEnumerable<int> InnerGetNumberByLocalMethod()
            {
                for (int i = start; i <= end; i++)
                {                    
                        yield return i;
                }
            }
        }
        public static IEnumerable<int> GetNumber(int start, int end)
        {
            throw new Exception("deliberately exception");
            for (int i = start; i <= end; i++)
            {                
                    yield return i;
            }
        }
To make sure local method version can get exception quickly, GetNumberByLocalMethod version will execute immediately and not wait until the first iterate.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
