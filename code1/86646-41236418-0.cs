     interface Itest
     {
          public void functiona();
          public void functionb();
     }
    class child : Itest
    {
         public void functiona()
         {
         }
         void Itest.functionb()
         {
         }
    }
