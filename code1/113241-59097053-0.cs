 c#
namespace MyLibrary {
   public static class MyLibraryAssembly {
      public static readonly Assembly Value = typeof(MyLibraryAssembly).Assembly;
   }
}
and then whenever you need a reference to that assembly:
 C#
var assembly = MyLibraryAssembly.Value;
