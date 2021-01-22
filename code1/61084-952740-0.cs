    using System;
    class Program
    {
        static void Main(string[] args)
        {
            string finPath = "videoinput/file.wmv";
            string foutPath = "C:\\Documents and Settings\\user\\My Documents\\Visual Studio 2008\\Projects\\projectname\\videooutput/eaf2cc1d-6mtnR.flv";
            string arguments = string.Format("-i \"{0}\" -ar 44100 -ab 160k \"{1}\"", finPath, foutPath);
            Console.WriteLine(arguments);
            Console.ReadKey();
            return;
        }
    }
