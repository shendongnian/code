    static int RecursiveMethod(int a(=1), int b(=3))
    {
        if (a == b) // FALSE
        {
            return a; // NOT EXECUTED
        }
        else 
        {
            return a(=1)                                                 // ==> RETURNS 1 + 5 = 6
                + RecursiveMethod(int a+1(=2), int b(=3))                                   ^
                  {                                                                         |
                      if (a == b) // FALSE                                                  |
                      {                                                                     |
                          return a; // NOT EXECUTED                                         |
                      }                                                                     |
                      else                                                                  |
                      {                                                                     |
                          return a(=2)                               // ==> RETURNS 2 + 3 = 5
                              + RecursiveMethod(int a+1(=3), int b(=3))                 ^
                                {                                                       |
                                    if (a == b) // TRUE                                 |
                                    {                                                   |
                                        return a;                        // ==> RETURNS 3
                                    }
                                    else 
                                    {
                                        return a + RecursiveMethod(a + 1, b); // NOT EXECUTED
                                    }
                                }                                           
                      }
                  }                                           
        }
    }
