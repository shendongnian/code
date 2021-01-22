    public class Item
    {
        public string Name;
        public Item Parent;
    }
    
    List<Item> Collection = new List<Item>();
    
    public void Main()
    {
        StreamReader Reader = new StreamReader(MapPath("TextFile.txt"));
        int LastLevel = 0;
        
        while (Reader.EndOfStream == false) {
            var line = Reader.ReadLine();
            var Level = line.Where((System.Object c) => c == "-").Count;
            
            if (Level == 0) {
                Collection.Add(new Item { Name = line });
                LastLevel = 0;
            }
            else if (Level - LastLevel == 1) {
                Collection.Add(new Item { Name = line, Parent = Collection.Last() });
                LastLevel += 1;
            }
            
        }
    }
