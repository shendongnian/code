    class MyKey : IComparable {
       public string Key1 {get;set;}
       public string Key2 {get;set;}
       public int CompareTo(object o) {
          if(!(o is MyKey))
             return -1;
          int k1 = Key1.CompareTo(((MyKey)o).Key1);
          return k1 == 0 ? Key2.CompareTo(((MyKey)o).Key2) : k1;
       }
    }
    Dictionary<MyKey, string> myKewlDictionary...
