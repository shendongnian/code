    using System.Linq; // from System.Core.  otherwise just translate linq to for-each
    using System.IO;
    public Stream GetStream(string fileName) {
        // assume we want a resource from the same that called us
        var ass = Assembly.GetCallingAssembly();
        var fullName = GetResourceName(fileName, ass);
        //  ^^ should = MyCorp.FunnyApplication.Mp3Files.<filename>, or similar
        return ass.GetManifestResourceStream(fullName);
    }
    // looks up a fully qualified resource name from just the file name.  this is
    // so you don't have to worry about any namespace issues/folder depth, etc.
    public static string GetResourceName(string fileName, Assembly ass) {
        var names = ass.GetManifestResourceNames().Where(n => n.EndsWith(fileName)).ToArray();
        if (names.Count() > 1) throw new Exception("Multiple matches found.");
        return names[0];
    }    
    var mp3Stream = GetStream("startup-sound.mp3");
    var mp3 = new MyMp3Class(mp3stream);  // some player-related class that uses the stream
    
