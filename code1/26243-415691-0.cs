    using System.IO;
    public class ExternalApplication
    {
       public ExternalApplication(string path)
       {
          this.Path = path;
       }
       public string Path { get; protected set; }
       public bool Exists() 
       {
          if(string.IsNullOrEmpty(this.Path))
             throw new ConfigurationException("Path not specified.");
          return File.Exists(this.Path);
       }
       public void Execute(string args)
       {
          // Implementation to launch the application
       } 
    }
    public class AppFactory
    {
       public ExternalApplication App1()
       {
          // Implementation to initialize this application from
          // the application's configuration file.
       }
       public ExternalApplication App2()
       {
          // Implementation to initialize this application from
          // the application's configuration file.
       }
    
       public ExternalApplication AppFromKey(string key)
       {
          // get from somewhere
       } 
     }
