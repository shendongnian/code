    class Program {
       static void Main(string[] args)
       {
          PointF p = new PointF(0, 0);
          
          p.SetFlag(true);
          if (p.GetFlag())
             Console.WriteLine("win");
       }
    }
    public static class Extensions
    {
       private static Dictionary<PointF, bool> flags = new Dictionary<PointF, bool>();
       public static bool GetFlag(this PointF key)
       {
          return flags[key];
          //OR return flags.ContainsKey(key) ? flags[key] : false;
       }
       public static void SetFlag(this PointF key, bool val)
       {
          flags[key] = val;
       }
    }
