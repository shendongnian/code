     public Foo FooUpdate(Foo item, params Action<Foo> properties)
     {
         foreach(var property in properties)
         {
            property(item);
         }
         return item
     } 
