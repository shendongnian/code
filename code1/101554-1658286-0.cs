    public static bool operator ==(MyObj a, MyObj b)
    {
      // don't do this!
      return true;
    }
    ...
    MyObj a = new MyObj();
    MyObj b = null;
    Console.WriteLine(a == b); // prints true
    Console.WriteLine((object)a == (object)b); // prints false
