    private static bool _isValid = true;
    static void Main(string[] args)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (FileStream file = new FileStream("C:\\MyFolder\\Product.dtd", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int) file.Length);
                ms.Write(bytes, 0, (int) file.Length);
            }
            using (FileStream file = new FileStream("C:\\MyFolder\\Product.xml", FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int) file.Length);
                ms.Write(bytes, 0, (int) file.Length);
            }
            ms.Position = 0;
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(OnValidationEvent);
            var reader = XmlReader.Create(ms, settings);
            // Parse the file.  
            while (reader.Read()) ;
        }
        // Check whether the document is valid or invalid.
        if (_isValid)
            Console.WriteLine("Document is valid");
        else
            Console.WriteLine("Document is invalid");
    }
    private static void OnValidationEvent(object obj, ValidationEventArgs args)
    {
        _isValid = false;
        Console.WriteLine("Validation event\n" + args.Message);
    }
