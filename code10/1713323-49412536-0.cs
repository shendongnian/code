     [XmlInclude(typeof(MenuSubmenu))]
     [XmlInclude(typeof(MenuItem))]
     public abstract class TreeviewMenuItem
    { 
        public virtual string Text { get; set; }
        public virtual string DisplayName { get => Text; }
        [XmlIgnore]
        public virtual MenuSubmenu ParentMenu { get; set; } = null;
    }
    
    public class MenuSubmenu : TreeviewMenuItem
    {        
        public override string DisplayName { get => Text + " [" + Items.Count + "]"; }       
              [XmlArrayItem(Type = typeof(TreeviewMenuItem)),   
               XmlArrayItem(Type = typeof(MenuSubmenu))] 
        public List<MenuItem> Items { get; set; }
    
        public MenuSubmenu(MenuSubmenu parent = null)
        {
            Items = new List<MenuItem>();
        }
    }
    public class MenuItem : TreeviewMenuItem
    {
        public MenuItem(MenuSubmenu parent = null)
        {
            ParentMenu = parent;
        }
    }
