    string name = "Resources.myimage.jpg"
    string namespaceName = "MyCompany.MyNamespace";
    string resource = namespaceName + "." + name;
    Type type = typeof(MyCompany.MyNamespace.MyTypeFromSameAssemblyAsResource);
    Bitmap image = new Bitmap(type.Assembly.GetManifestResourceStream(resource));
