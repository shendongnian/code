    using System.Runtime.InteropServices;
    public static class Util
    {
      [DllImport( "shlwapi.dll", EntryPoint = "PathRelativePathTo" )]
      protected static extern bool PathRelativePathTo( StringBuilder lpszDst,
          string from, UInt32 attrFrom,
          string to, UInt32 attrTo );
      public static string GetRelativePath( string from, string to )
      {
        StringBuilder builder = new StringBuilder( 1024 );
        bool result = PathRelativePathTo( builder, from, 0, to, 0 );
        return builder.ToString();
      }
    }
