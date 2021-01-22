    public static class RandomProvider {
    
       private static Random _rnd = new Random();
       private static object _sync = new object();
       public static int Next() {
          lock (_sync) {
             return _rnd.Next();
          }
       }
       public static int Next(int max) {
          lock (_sync) {
             return _rnd.Next(max);
          }
       }
    
       public static int Next(int min, int max) {
          lock (_sync) {
             return _rnd.Next(min, max);
          }
       }
    
    }
