    abstract class DocumentGeneratorFactory
    {
      public static DocumentGenerator GetGenerator(FileType eFileType)
      {
        switch (eFileType)
        {
          // a hash of FileType => Generator
          default:
            return new LetsSayCSVGenerator();
        }
    
      }
    }
    
    class Program
    {
      static void Main(string[] args)
      {
        DocumentGenerator d = DocumentGeneratorFactory.GetGenerator(FileType.CSV);
        FileInfo f = d.Generate("ItsAlive.CSV");
      }
    }
