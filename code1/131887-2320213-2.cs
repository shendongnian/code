    public class Item
    {
        public string Name;
        public Item Parent;
    }
    
    List<Item> Collection = new List<Item>();
    
    public void Main()
    {
        var DataSource = data.InnerText;
        
        StreamReader Reader = new StreamReader(MapPath("_test2.txt"));
        int LastLevel = 0;
        
        while (Reader.EndOfStream == false) {
            var line = Reader.ReadLine();
            var Level = line.Where((System.Object c) => c == "-").Count;
            Item LastItem = default(Item);
            
            if (Collection.Count != 0) {
                LastItem = Collection.Last();
            }
            
            if (Level == 0) {
                Collection.Add(new Item { Name = line });
                LastLevel = 0;
            }
            else if (Level - LastLevel == 1) {
                Collection.Add(new Item { Name = line, Parent = LastItem });
                LastLevel += 1;
            }
            else if (Level == LastLevel) {
                Collection.Add(new Item { Name = line, Parent = LastItem.Parent });
            }
            else if (Level < LastLevel) {
                var LevelDiff = LastLevel - Level;
                Item Parent = LastItem;
                
                for (i = 0; i <= LevelDiff; i++) {
                    Parent = Parent.Parent;
                }
                
                LastLevel = Level;
                Collection.Add(new Item { Name = line, Parent = Parent });
            }
        }
        
        Reader.Close();
    }
