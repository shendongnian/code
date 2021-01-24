    public class Immutable
    {
        public Immutable(string[] args)
        {
             InputFolder = args[0];
             OutputFolder = args[1];
        }
        public readonly string InputFolder {get;}
        public readonly string OutputFolder {get;}
    }
