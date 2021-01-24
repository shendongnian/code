    using System;
    using Android.App;
    using System.IO;
    using PCLStorage;
    
    namespace App.Droid.AndroidSpecificSetters
    {
        public class AndroidConfiguration    
    
            public async void copyElementDatabaseToLocalStorage()
            {
                string localStorage = FileSystem.Current.LocalStorage.Path;
                string databaseLocation = Path.Combine(localStorage, "counters.db3");
            try
            {
                if (!File.Exists(databaseLocation))
                {
                    using (var binaryReader = new BinaryReader(Application.Context.Assets.Open("counters.db3")))
                    {
                        using (var binaryWriter = new BinaryWriter(new FileStream(databaseLocation, FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int length = 0;
                            while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                binaryWriter.Write(buffer, 0, length);
                            }
                        }
                    }
                }
            } catch (Exception e)
            {
               ...
            }
        }
       }
    }
