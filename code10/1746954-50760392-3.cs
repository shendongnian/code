    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = "ConsoleApp2.Folder1.File1.bin";
    MyClass mc;
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    {
        var bf = new BinaryFormatter();
        mc = (MyClass)bf.Deserialize(stream);
    }
