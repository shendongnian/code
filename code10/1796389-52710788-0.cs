    Xpcom.ComponentRegistrar.AutoRegister():
    
    void RegisterExtensionDir(string dir)
    {
            Console.WriteLine("Registering binary extension directory:  " + dir);
            var chromeDir = (nsIFile)Xpcom.NewNativeLocalFile(dir);
            var chromeFile = chromeDir.Clone();
            chromeFile.Append(new nsAString("chrome.manifest"));
            Xpcom.ComponentRegistrar.AutoRegister(chromeFile);
    }
