    class A {
    
       private SortedList<string, string> _list;
    
       public A() {
          _list = new SortedList<string, string>()
       }
    
       public string this[string key] {
          get {
             return _list[key];
          }
          set {
             _list[key] = value;
          }
       }
    
    }
