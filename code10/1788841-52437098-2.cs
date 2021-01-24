    using System;
    using Xamarin.Forms;
    using sharedTest;//your xamarin.forms name
    using sharedTest.Droid;
    using System.IO;
    
    [assembly: Dependency(typeof(MyAndroidClass)) ]
    namespace sharedTest.Droid 
    {
        public class MyAndroidClass: MyClass.IGetFilePath
        {
            public MyAndroidClass()
            {
            
            }
            public string PlatformGetFilePath(string filename)
           {
             string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
             string filepath = Path.Combine(libraryPath, filename);
             return filepath; 
           }
       }
    }
