     public class MainEntity
     {
        public SubEntity AssociatedEntity;
        public MainEntity()
        {
            // This is where the instantiation happen.
            AssociatedEntity = new SubEntity(); 
        }
     }
     public class SubEntity
     {
        public string property1;
     }
        
