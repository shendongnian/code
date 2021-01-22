     public class MyClassRepository : Repository<MyClass>
     {
         public override MyClass GetById( int id )
         {
             return this.SingleOrDefault( c => c.MyClassID );
         }
     }
