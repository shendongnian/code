    void test()
    {
      foo();
      //timer for the following statements
      using (new MyTimer("Some method"))
      {
        bar();
      }
      baz();
    }
