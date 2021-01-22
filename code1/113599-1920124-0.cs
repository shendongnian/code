    using (TextWriter writer = File.CreateText("foo.cs"))
    {
        foreach (string usingDirective in usingDirectives)
        {
            writer.WriteLine("using {0};", usingDirective);
        }
        writer.WriteLine();
        writer.WriteLine("namespace {0}", targetNamespace);
        // etc
    }
