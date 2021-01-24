    List<Class1> Pokedex = new List<Class1>();
    string[] delimiters = { "," };
    using (TextFieldParser parser = FileSystem.OpenTextFieldParser("Names.txt", delimiters))
    {
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();
            // populate your class here
            Class1 Dex = new Class1();
            Dex.DexNumber = fields[0];
            Dex.Name = fields[1];
            // add the other fields here
           Pokedex.Add(Dex);
        }
    }
