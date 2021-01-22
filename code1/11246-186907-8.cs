    int x = 1;
    Change(ref x);
    Debug.Assert(x == 5);
    WillNotChange(x);
    Debug.Assert(x == 5); // Note: x doesn't become 10
    void Change(ref int x)
    {
      x = 5;
    }
    void WillNotChange(int x)
    {
      x = 10;
    }
