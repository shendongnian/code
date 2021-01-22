    public class FileOptions
    {
      public bool Indented { get; set; }
      public string Namespace { get; set; }
      public System.Text.Encoding Encoding { get; set; }
    }
    
    public void Save(string fileName, FileOptions options) { ... }
    
    // usage:
    
    obj.Save("a.xml", new FileOptions { Indented=true });
    obj.Save("b.xml", new FileOptions { Namespace="urn:foo", Encoding=System.Text.Encoding.UTF8 });
