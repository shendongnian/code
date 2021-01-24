    public class Snippet
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    
    // saving loading
    var snippets = new List<Snippet>()
    {
        new Snippet(){Name="Saving", Code = "//Code to save\n//to Disk"},
        new Snippet(){Name="Loaidng", Code = "//Code to load\n//from Disk"}
    };
    var json =  JsonConvert.SerializeObject(snippets);
    File.WriteAllText("snippets.json", json);
    
    var loadedSnippets = JsonConvert.DeserializeObject<List<Snippet>>(File.ReadAllText("snippets.json"));
    loadedSnippets.ForEach(s => Console.WriteLine(s.Name));
    
            
