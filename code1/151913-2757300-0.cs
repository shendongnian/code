    unsafe struct s1
    {
      public int a;
      public int b;
    }
  
    unsafe struct s
    {
      public fixed ulong otherStruct[100];
    }
    unsafe void f() {
      var S = new s();
      var S1 = new s1();
      S.otherStruct[4] = (ulong)&S1;
      var S2 = (s1*)S.otherStruct[4];
    }
