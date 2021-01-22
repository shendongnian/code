    using System.Linq; // from System.Core.  otherwise just translate linq to for-each
    public System.IO.Stream GetMp3(string fileName) {
        // assume we want a resource from the same that called us
        var ass = Assembly.GetCallingAssembly();
        var fullName = GetResourceName(fileName, ass);
        //  ^^ should = MyCorp.FunnyApplication.Mp3Files.<filename>, or similar
        return ass.GetManifestResourceStream(fullName);
    }
    // looks up a fully qualified resource name from just the file name.  this is
    // so you don't have to worry about any namespace issues/folder depth, etc.
    public static string GetResourceName(string fileName, Assembly ass) {
         var names = ass.GetManifestResourceNames().Where(n=>n.EndsWith(fileName))
         if (names.Count > 1) then throw new Exception("Multiple matches found.")
         return names[0];
    }    
    var myMp3 = GetMp3("startup-sound.mp3")
    
