     interface Itest
     {
          void functiona();
          void functionb();
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
