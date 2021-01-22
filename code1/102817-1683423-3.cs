    void SetOne(out int x) 
    {
      int y = x + 1; // error, 'x' not definitely assigned.
      x = 1;         // mandatory to assign something
    }
    void AddTwo(ref int x)
    {
        x = x + 2;  // OK, x  is known to be assigned
    }
    void Main()
    {
        int foo, bar;
        SetOne(out foo); // OK, foo does not have to be assigned
        AddTwo(ref foo); // OK, foo assigned by SetOne
        AddTwo(ref bar); // error, bar is unassigned
    }
