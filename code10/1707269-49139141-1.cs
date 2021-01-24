    class BackgroundColorSaver : IPreprocessBuild
    {
        public int callbackOrder { get { return 0; } } // Set this accordingly
        public void OnPreprocessBuild(BuildTarget target, string path)
        {
            SaveBkgColor();
        }
        [MenuItem("MyMenu/Save Background Splash Color")]
        public static void SaveBkgColor()
        {
            // Save PlayerSettings.SplashScreen.backgroundColor to a
            // file somewhere in your "Resources" directory 
        }
    }
