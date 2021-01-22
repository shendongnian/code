    class A
    {
       static int needsToBeThreadSafe = 0;
       static object statObjLocker = new object();
    
       public static void M1()
       {
           lock(statObjLocker)
           {
              needsToBeThreadSafe = RandomNumber();
           }
       }
    
       public static void M2()
       {
           lock(statObjLocker)
           {
              print(needsToBeThreadSafe);
           }
       }
    }
