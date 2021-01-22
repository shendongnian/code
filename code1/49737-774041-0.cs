    public static class SequenceHelper
    {
       private static int ID;
       private static object LockObject = new object();
       public static int GetNextID()
       {
          lock (LockObject)
          {
             return ID++;
          }
       }
    }
