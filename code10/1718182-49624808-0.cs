    #r "System.IO"
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    public static void Run(Stream myBlob, string name, TraceWriter log)
    {
        log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        StreamReader reader = new StreamReader(myBlob);
        string  oldContent = reader.ReadToEnd();
        log.Info($"oldContent:{oldContent}");
        
    }
