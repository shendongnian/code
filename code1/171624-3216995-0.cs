    using System;
    using System.IO;
    
    public class CommandLine
    {
       public static void Main(string[] args)
       {
           // The path is passed as the first argument
           string fileName = arg[0];
           // get absolute path
           fileName = Path.GetFullPath(fileName);
           // TODO: do whatever needs to done with the passed file name
       }
}
