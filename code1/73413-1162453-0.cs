    int minVal(test1 t1) {
       int min = t1.val;
       foreach (test2 t2 in t1.Tests) {
          min = Math.Min(min, t2.val);
          foreach (test3 t3 in t2.Tests) {
             min = Math.Min(min, t3.val);
             foreach (test4 t4 in t3.Tests) {
                 min = Math.Min(min, t4.val);
             }
          }
       }
       return min;
    }
