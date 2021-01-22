          private static void DoOne()
          {
             C c = new C();
             int s = 0;
             for (int j = 0; j < 100000; j++)
             {
                for (int i = 0; i < c.Count; i++) s += c.f();
             }
    
          }
          private static void DoTwo()
          {
             VC c = new VC();
             int s = 0;
             for (int j = 0; j < 100000; j++)
             {
                for (int i = 0; i < c.Count; i++) s += c.f();
             }
    
          }
