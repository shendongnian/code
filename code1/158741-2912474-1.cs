    using System.IO;
    using System.Linq;
    var firstFile = Directory.GetFiles(@"c:\dir", "*.*")
        .FirstOrDefault(f => !String.Equals(
            Path.GetFileName(f),
            "Thumbs.db",
            StringComparison.InvariantCultureIgnoreCase));
