     public static void doStuff(List<int?> nullableList)
            {            
    
                var firstItem = nullableList.FirstOrDefault();
                if (firstItem != null)
                    Console.WriteLine(firstItem);
                else
                    Console.WriteLine("first item is null");
            }
