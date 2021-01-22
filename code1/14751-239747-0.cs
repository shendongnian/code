    public class MyItem {
    
        internal MyItemManager manager { get;set; }
    
        public string Property1 { 
            get { return manager.GetPropertyForItem( this ); } 
        }
    }
