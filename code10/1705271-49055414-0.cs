     static void Main(string[] args)
            {
    
                var collection = new List<string> { "A", "B", "C", "D", "E" };
    
                var items = collection.Select((item, index) => new
                {
                    Item = item,
                    PreVItem = index > 0 ? collection[index - 1] : null,
                    NextItem = index < collection.Count-1 ? collection[index + 1] : null
                });
    
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.PreVItem} \t {item.Item} \t {item.NextItem}");
                }
    
                
                Console.ReadLine();
            }
