    private static int[] _widget = new int[Counter];
    public static int [] Widget {
             get { return _widget; }
             set { _widget = value; }
    }
....
    for (int i = 0; i <  MyClass.Counter; i++) {
        MyClass.Widget[i] = i;
    }
    ...
    double _newWidget5 = MyClass.Widget[5];
    // and so on...
