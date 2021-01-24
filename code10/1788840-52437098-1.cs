    using System;
    using System.IO;
    using sharedTest;//your xamarin.forms name
    using sharedTest.iOS;
    using Xamarin.Forms;
    
    [assembly: Dependency(typeof(MyiOSClass))]
    namespace sharedTest.iOS
    {
        public class MyiOSClass:MyClass.IGetFilePath
        {
            public MyiOSClass()
            {
            }
            public string PlatformGetFilePath(string filename)
            {
             string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
             string libraryPath = Path.Combine(documentsPath, "..", "Library");
             string filepath = Path.Combine(libraryPath, filename);
             return filepath;
            }
        }
    }
