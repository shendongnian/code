    string name = "Resources.myimage.jpg"
    string namespace = "MyCompany.MyNamespace";
    string resource = namespace + "." + name;
    Type type = typeof(MyCompany.MyNamespace.MyTypeFromSameAssemblyAsResource);
    Bitmap image = new Bitmap(type.Assembly.GetManifestResourceStream(resource));
