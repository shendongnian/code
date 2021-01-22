    private static object obj = new object(); // only used for locking
    public static string MyConfigString {
        get {
           lock(obj)
           {
              return myConfigstring;
           }
        }
        set {
           lock(obj)
           {
              myConfigstring = value;
           }
        }
    }
