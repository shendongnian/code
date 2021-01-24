        public class CustomViewCell: ListView
       {
           public ITemplatedItemsList<Cell> TemplatedItem
           {
               get { return ((ITemplatedItemsView<Cell>)this).TemplatedItems; }
           }        
       }
    
