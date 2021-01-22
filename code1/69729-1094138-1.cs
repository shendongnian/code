    [ComImport, TypeLibType(...), Guid("..."), DefaultMember("Name")]
    public interface _Application
    {
         ...
    }
    [ComImport, Guid("..."), CoClass(typeof(ApplicationClass))]
    public interface Application : _Application
    {
    }
    [ComImport, ClassInterface(...), ComSourceInterfaces("..."), Guid("..."), 
     TypeLibType((short) 2), DefaultMember("Name")]
    public class ApplicationClass : _Application, Application
    {
    }
