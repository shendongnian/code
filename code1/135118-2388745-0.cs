    protected void Page_Load(object sender, EventArgs e)
    {
        string contents = ReadEmbeddedResource("ClassLibrary1", "ClassLibrary1.TestJavaScript.js");
        //replace part of contents
        //write new contents to response
        Response.Write(String.Format("<script>{0}</script>", contents));
    }
    private string ReadEmbeddedResource(string assemblyName, string resouceName)
    {
        var assembly = Assembly.Load(assemblyName);
        using (var stream = assembly.GetManifestResourceStream(resouceName))
        using(var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
