    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    
    namespace Tests.Console
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fileName = "c:\\toto.txt";
                var content = File.ReadAllLines(fileName).ToList();
                var selected = content[new Random().Next(0, content.Count)];
    
                Debug.Write(selected);
    
                content.Remove(selected);
                File.WriteAllLines(fileName, content.ToArray());
            }
        }
    }
