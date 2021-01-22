    public class HiResDateTime
    {
       private static long lastTimeStamp = DateTime.UtcNow.Ticks;
       public static long UtcNowTicks
       {
           get
           {
               long orig, newval;
               do
               {
                   orig = lastTimeStamp;
                   long now = DateTime.UtcNow.Ticks;
                   newval = Math.Max(now, orig + 1);
               } while (Interlocked.CompareExchange
                            (ref lastTimeStamp, newval, orig) != orig);
               return newval;
           }
       }
    }
