    string text = @"Foo
    Bar
    Baz
    Bla
    Fasel";
    using (var reader = new StringReader(text))
    using (var trackingReader = new TrackingTextReader(reader))
    {
        string line;
        while ((line = trackingReader.ReadLine()) != null)
        {
            Console.WriteLine("{0:d3} {1}", trackingReader.Position, line);
        }
    }
