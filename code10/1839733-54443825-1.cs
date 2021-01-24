    static void Main(string[] args)
    {
        var engine = new TemplateEngine();
        var sampleTemplate = engine.GetTemplate<SampleTemplate>();
    
        Console.WriteLine($"{sampleTemplate.DataName}"); // SampleTemplateData
    }
