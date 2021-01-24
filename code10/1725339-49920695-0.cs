    string templatefile = System.IO.Path.GetTempFileName();
    MemoryStream ms = new MemoryStream(); 
    _assembly.GetManifestResourceStream("SwitchConfigReader.Resources.template_hm_mach10x.xlsx").CopyTo(ms);
    Byte[] bArray = ms.ToArray();
    System.IO.File.WriteAllBytes(templatefile, bArray);
    Excel excel = new Excel(templatefile, 1);
