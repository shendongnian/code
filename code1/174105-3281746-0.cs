    public static void readXMLOutput(Stream stream){
        string streamContents;
        using(var sr = new StreamReader(stream)){
            streamContents = sr.ReadToEnd();
        }
        
        var document = XDocument.Load(streamContents);
    }
