    public class Values { 
      public static string BinDir;
      public static string OtherDir { 
        get { return Path.Combine(BinDir,@"Some\Other\Path"); } 
      }
    }
