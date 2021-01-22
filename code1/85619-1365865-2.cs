    void Example2(int p1) {
      Action del = () => { p1 = 42; }
      del();
      Console.WriteLine(p1);
    }
