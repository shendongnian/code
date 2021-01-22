    JavaScriptSerializer jss = new JavaScriptSerializer();
    jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });
    dynamic glossaryEntry = jss.Deserialize(json, typeof(object)) as dynamic;
     
    Console.WriteLine("glossaryEntry.glossary.title: " + glossaryEntry.glossary.title);
    Console.WriteLine("glossaryEntry.glossary.GlossDiv.title: " + glossaryEntry.glossary.GlossDiv.title);
    Console.WriteLine("glossaryEntry.glossary.GlossDiv.GlossList.GlossEntry.ID: " + glossaryEntry.glossary.GlossDiv.GlossList.GlossEntry.ID);
    Console.WriteLine("glossaryEntry.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.para: " + glossaryEntry.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.para);
    foreach (var also in glossaryEntry.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso)
    {
        Console.WriteLine("glossaryEntry.glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso: " + also);
    }
