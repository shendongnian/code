    public class ImmutableObject
    {
        public ImmutableObject(string inputFolder, string outputFolder)
        {
            InputFolder = inputFolder;
            OutputFolder = outputFolder;
        }
        
        public string InputFolder {get;}
        public string OutputFolder {get;}
     }
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: MyTool <InputFolder> <OutputFolder>");
            return;
        }
        var folders = new ImmutableObject(args[0], args[1]);
    
        // ...
    }
