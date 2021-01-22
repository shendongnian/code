    private void Nullify(ref StringBuilder sb, string message)
    {
        sb.Append(message);
        sb = null;
    }
    
    // -- snip --
    
    StringBuilder sb = new StringBuilder();
    string message = "Hi Guy";
    Nullify(ref sb, message);
    System.Console.WriteLine(sb.ToString());
    
    // Output
    // NullReferenceException
