    class WrapperAB : IA, IB {
      IA a; IB b;
      public WrapperAB(object o) {
        if (o is IA) a = (IA)o;
        else if (o is IB) b = (IB)o;
        else throw new Exception();
      }
      public int Owner {
        set { 
          if (a != null) a.Owner = value; 
          else b.Owner = value; 
        }
      }
      public string Version() {
        if (a != null) return a.Version();
        else return b.Version();
      }
    }
