    // Class
    public class Item 
    {    
        public virtual int Id { get; set; }    
        public virtual string Name { get; set; }    
        public virtual Item Parent { get; private set; }
        public virtual IList<Item> Children { get; set; }    
        public Item() {        
            Children = new List<Item>();    
        }
     }
     // Map
     References(x => x.Parent).Column("ParentId");
     HasMany(x => x.Children).Cascade.All().KeyColumn("ParentId");
     // Add Item
     session.Save(new Item { Description = "Electronics", 
                            Children = { 
                                    new Item { Description = "PS2" },
                                    new Item { Description = "XBox" }
                            }});  
    // Get Item
    var items =
              (from c in session.Linq<Item>()
                     where c.Parent == null
                     select c).ToList();   
