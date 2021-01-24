    public abstract class DbLayer<T> {
        public virtual T Get(int Id) {
            // default implementation here
            // but virtual allows overriding   
        }
        public virtual T Create(T obj) {
            // default implementation here
            // but virtual allows overriding               
       }
    }
    public class FooBarDlo: DbLayer {
       public override FooBarDlo Get(int Id) {
           // override Get handling
                 
       }
    }
