    public class Item
    {
         public Item()
         {
             this.children = new ItemCollection(this);
         }
         public ItemCollection Children
         {
             get  { return this.children; }
         }
         private readonly ItemCollection children = null;
    
         public Item Parent
         {
             get { return this.parent; }
             set
             {
                 if (this.parent != null)
                 {
                     this.parent.Children.Remove(this);
                 }
                 if (value != null)
                 {
                     value.Children.Add(this);
                 }
             }
         }
         internal Item parent = null;
    }
