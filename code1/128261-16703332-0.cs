    StringBuilder sb = null;
    
    // StringWriter - a TextWriter backed by a StringBuilder
    using (var writer = new StringWriter())
    {
        writer.WriteLine("Blah");
        . . .
        sb = writer.GetStringBuilder(); // Get the backing StringBuilder out
    }
    
    // Do whatever you want with the StringBuilder
