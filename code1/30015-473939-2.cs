    interface IMyTable2<T> {
      DataContext DataContext {get; }
      Table<T> Table {get; }
    }
    
    class MyAdapter: IMyTable2<T> {
      private MyOtherClass<T> _other;
      public DataContext DataContext { get { return _other.DataContext } }
      public Table<T> Table { get { return _other.TableWithDifferentName; } }
    }
