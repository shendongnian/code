    DelimitedClassBuilder cb = new DelimitedClassBuilder("MyProduct", delimiter: ",");
    
    cb.AddField("Name", typeof(string));
    cb.LastField.TrimMode = TrimMode.Both;
    cb.AddField("Description", typeof(string));
    cb.LastField.FieldQuoted = true;
    cb.LastField.QuoteChar = '"';
    cb.LastField.QuoteMode = QuoteMode.OptionalForBoth;
    // etc... e.g., add a date field
    cb.AddField("SomeDate", typeof(DateTime));
    engine = new FileHelperEngine(cb.CreateRecordClass());
    DataTable dt = engine.ReadFileAsDT("test.txt");
