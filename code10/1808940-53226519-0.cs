    public class Immutable
    {
        public Immutable(string x, string y)
        {
             InputFolder = x;
             OutputFolder = y;
        }
        public readonly string InputFolder {get;}
        public readonly string OutputFolder {get;}
    }
