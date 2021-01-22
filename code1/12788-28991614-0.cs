    public class NewViewEngine : RazorViewEngine {
       private static readonly string[] NEW_PARTIAL_VIEW_FORMATS = new[] {
          "~/Views/Foo/{0}.cshtml",
          "~/Views/Shared/Bar/{0}.cshtml"
       };
 
       public NewViewEngine() {
          // Keep existing locations in sync
          base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NEW_PARTIAL_VIEW_FORMATS).ToArray();
       }
    }
