    class Foo {
         public override bool Equals(object obj)
         {
             // The more specific function needs to do null checking anyway.
             return Equals(obj as Foo);
         }
    
         public bool Equals(Foo obj)
         {
             // do some comparison here.
         }
    }
