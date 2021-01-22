        ...
  
        IIdentifiable ipod = new IPod(); 
        IIdentifiable gardfield = new Cat();
         
        store( ipod );
        store( gardfield );
        ....
        public void store( IIdentifiable object )  
        {
             long uniqueId = object.GetUniqueId();
            // save it to db or whatever.
        }
           
