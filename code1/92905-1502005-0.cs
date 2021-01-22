      public class FavouriteSettings
      {
        public ID[] Customer
        {
          get;
          set;
        }
    
        public ID[] Supplier
        {
          get;
          set;
        }
      }
    
      public class ID
      {
        [XmlText()]
        public int Value
        {
          get;
          set;
        }
      }
     
