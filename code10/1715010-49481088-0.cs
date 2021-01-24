    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(TextPage)).Assembly;
    Stream stream = assembly.GetManifestResourceStream("JP.Texts.JP.txt");
    string text = "";
    using (var reader = new System.IO.StreamReader (stream)) {
        text = reader.ReadToEnd ();
    }
    Debug.WriteLine(text);
