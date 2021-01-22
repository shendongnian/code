    using System;
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidReleaseToApp : Attribute
    {
        private string _releaseToApplication;
        public string ReleaseToApplication { get { return _releaseToApplication; } }
    
        public ValidReleaseToApp(string ReleaseToApp)
        {
            this._releaseToApplication = ReleaseToApp;
        }
    } 
    
    
    Assembly a = Assembly.LoadFrom(PathToDLL);
    Type type = a.GetType("Namespace.ClassName", true);
    System.Reflection.MemberInfo info = type;
    var attributes = info.GetCustomAttributes(true);
    if(attributes[0] is ValidReleaseToApp){
       string value = ((ValidReleaseToApp)attributes[0]).ReleaseToApplication ;
       MessageBox.Show(value);
    }
