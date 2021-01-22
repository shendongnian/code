    public int Add(int val1, int val2, out object outputz)
    {
        int total = val1 + val2;
        outputz = new object[5]
          {
              "test1",
              "test2",
              "test3",
              "test4",
              "test5"
          };
    
        return total;
    }
