    using System.IO;
    using System.Reflection;
    using System.Collections;
    using System.Resources;
    ...
    var icons = new Dictionary<String, Bitmap>();
    var externalBaml = Assembly.LoadFile(Path.Combine(Environment.CurrentDirectory, "MyXaml.dll"));
    Stream resourceStream = externalBaml.GetManifestResourceStream(externalBaml.GetName().Name + ".g.resources");
    using (ResourceReader resourceReader = new ResourceReader(resourceStream)) {
        foreach (DictionaryEntry resourceEntry in resourceReader) {
            if (resourceEntry.Key.ToString().ToUpper().EndsWith(".ICO")) {
                icons.Add(resourceEntry.Key.ToString(), Image.FromStream(resourceEntry.Value as Stream) as Bitmap);
            }
        }
    }
