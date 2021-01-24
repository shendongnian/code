    public static void UpdateAssembly()
    {
        string dllFile = "DynamicResources.temp";
        string dllNamespace = "DynamicResources";
        
        var asm = AssemblyDefinition.ReadAssembly(dllFile);            
        var module = asm.Modules.FirstOrDefault();
        var resources = module.Resources;
        var dllResource = (EmbeddedResource)(resources.FirstOrDefault());
        var dllResourceReader = new ResourceReader(dllResource.GetResourceStream());
        var newResourceOutputStream = new MemoryStream();
        var newResourceWriter = new ResourceWriter(newResourceOutputStream);
        foreach (DictionaryEntry dllResourceEntry in dllResourceReader)
        {
           var image = (BitmapSource)new ImageSourceConverter().ConvertFrom(dllResourceEntry.Value);
        
           Color foreground = (Color)ColorConverter.ConvertFromString("#FFFFFF");
           var processed = (WriteableBitmap)ColorizeImage(image, foreground); // Your image processing function ?
        
           newResourceWriter.AddResource(dllResourceEntry.Key.ToString(), BitmapToByte(processed));       
        }
        newResourceWriter.Close();
        
        var newResource = new EmbeddedResource(dllResource.Name, dllResource.Attributes, newResourceOutputStream.ToArray());
        module.Resources.Remove(dllResource);
        module.Resources.Add(newResource);
        
        var woutput = new MemoryStream();
        var wparams = new WriterParameters();
        asm.Write(woutput);
        var doutput = woutput.ToArray();
        Assembly assembly = Assembly.Load(doutput);
    }
    public static MemoryStream BitmapToByte(BitmapSource bitmapSource)
    {
        var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
        var frame = System.Windows.Media.Imaging.BitmapFrame.Create(bitmapSource);
        encoder.Frames.Add(frame);
        var stream = new MemoryStream();
        encoder.Save(stream);
        return stream;
    }
    public static void AttachAssembly(string myAsmFileName)
    {
        Assembly assembly = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + myAsmFileName); // LoadFrom
        AppDomain.CurrentDomain.Load(assembly.GetName());
    }
