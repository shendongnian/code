    public interface ICell<T> {
       T Item{ get; set; }
       ICell<T>{ get; set; }
    }
    class Cons<T> : ICell<T> {
      public T Item{ get; set; } /* C#3 auto-backed property */
      public Cell<T> Next{ get; set; }
    }
    
    class EmptyCell<T> : ICell<T>{
      public T Item{ get{ return default(T); set{ /* do nothing */ }; }
      public ICell<T> Next{ get{ return null }; set{ /* do nothing */; }
    }
