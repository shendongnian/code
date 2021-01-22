    using System;
    using System.IO;
    using System.Security.Permissions;
    class Test
    {
        static void Main()
        {
            // Load application settings.
            AppSettings appSettings = new AppSettings();
            Console.WriteLine("App settings:\nAspect Ratio: {0}, " +
                "Lookup directory: {1},\nAuto save time: {2} minutes, " +
                "Show status bar: {3}\n",
                new Object[4]{appSettings.AspectRatio.ToString(),
                appSettings.LookupDir, appSettings.AutoSaveTime.ToString(),
                appSettings.ShowStatusBar.ToString()});
    
            // Change the settings.
            appSettings.AspectRatio   = 1.250F;
            appSettings.LookupDir     = @"C:\Temp";
            appSettings.AutoSaveTime  = 10;
            appSettings.ShowStatusBar = true;
    
            // Save the new settings.
            appSettings.Close();
        }
    }
    
    // Store and retrieve application settings.
    class AppSettings
    {
        const string fileName = "AppSettings#@@#.dat";
        float  aspectRatio;
        string lookupDir;
        int    autoSaveTime;
        bool   showStatusBar;
    
        public float AspectRatio
        {
            get{ return aspectRatio; }
            set{ aspectRatio = value; }
        }
    
        public string LookupDir
        {
            get{ return lookupDir; }
            set{ lookupDir = value; }
        }
    
        public int AutoSaveTime
        {
            get{ return autoSaveTime; }
            set{ autoSaveTime = value; }
        }
    
        public bool ShowStatusBar
        {
            get{ return showStatusBar; }
            set{ showStatusBar = value; }
        }
    
        public AppSettings()
        {
            // Create default application settings.
            aspectRatio   = 1.3333F;
            lookupDir     = @"C:\AppDirectory";
            autoSaveTime  = 30;
            showStatusBar = false;
    
            if(File.Exists(fileName))
            {
                BinaryReader binReader =
                    new BinaryReader(File.Open(fileName, FileMode.Open));
                try
                {
                    // If the file is not empty,
                    // read the application settings.
                    // First read 4 bytes into a buffer to
                    // determine if the file is empty.
                    byte[] testArray = new byte[3];
                    int count = binReader.Read(testArray, 0, 3);
    
                    if (count != 0)
                    {
                        // Reset the position in the stream to zero.
                        binReader.BaseStream.Seek(0, SeekOrigin.Begin);
    
                        aspectRatio   = binReader.ReadSingle();
                        lookupDir     = binReader.ReadString();
                        autoSaveTime  = binReader.ReadInt32();
                        showStatusBar = binReader.ReadBoolean();
                    }
                }
    
                // If the end of the stream is reached before reading
                // the four data values, ignore the error and use the
                // default settings for the remaining values.
                catch(EndOfStreamException e)
                {
                    Console.WriteLine("{0} caught and ignored. " +
                        "Using default values.", e.GetType().Name);
                }
                finally
                {
                    binReader.Close();
                }
            }
    
        }
    
        // Create a file and store the application settings.
        public void Close()
        {
            using(BinaryWriter binWriter =
                new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                binWriter.Write(aspectRatio);
                binWriter.Write(lookupDir);
                binWriter.Write(autoSaveTime);
                binWriter.Write(showStatusBar);
            }
        }
    }
