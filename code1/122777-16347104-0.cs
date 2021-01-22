    XmlReader instance = new XmlTextReader ("instance.xml");
    XmlReader grammar = new XmlTextReader ("grammar.rng");
    using (RelaxngValidatingReader reader = new RelaxngValidatingReader (instance, grammar)) {
        try {
            while (!reader.EOF) {
                reader.Read();
            }
            Console.WriteLine("validation succeeded");
        }
        catch (Exception ex) {
            Console.WriteLine("validation failed with message:");
            Console.WriteLine(ex.Message);
        }
    }
