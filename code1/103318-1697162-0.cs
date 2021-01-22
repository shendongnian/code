    namespace ConsoleApplication3
    {
        //this is a node of your tree, but you may add whatever you want inside
        class Item
        {
            public List<Item> Items { get; set; }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                //define the tree structure
                var tree = new Item();
    
                // (complete your tree-structrure)
    
                //define the action delegate
                Action<Item> action = (item) => Console.WriteLine(item);
    
                //scan the hierarchy
                Scan(
                    tree,
                    typeof(Item),
                    action);
            }
    
    
            //here is the flat-scan function, the "typeToFind" here is just
            //for example and have very little sense to be in
            static void Scan(
                Item startItem,
                Type typeToFind,
                Action<Item> action)
            {
                var temp = new List<Item>();
                temp.Add(startItem);
    
                while (temp.Count > 0)
                {
                    var item = temp[0];
                    temp.RemoveAt(0);
    
                    if (typeToFind.IsInstanceOfType(item))
                    {
                        action(item);
                    }
    
                    temp.AddRange(item.Items);
                }
            }
        }
    }
