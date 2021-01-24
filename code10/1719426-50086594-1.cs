       using System;
       using System.Collections.Generic;
       using System.IO;
       using System.Linq;
       using System.Text.RegularExpressions;
       namespace ConsoleApp1
        {
        class Program
          {
               static void Main(string[] args)
            {
            
        
          string filepath = @"C:\Users\yasir\Documents\Visual Studio 2017\Projects\ConsoleApp1\ConsoleApp1\Product.cs";
            //1.getting file count
            int linecount = CountLines(filepath);
            Console.WriteLine($"total number of lines in program file is:{linecount}");
            //2.identifying reserved words
            ReservedWords(filepath);
            //discarding comments
           Console.WriteLine( DeleteComments(filepath));
           
           
          
           
            Console.ReadKey();
        }
        public static void ReservedWords(string filepath)
        {
            StreamReader sreader = new StreamReader(filepath);
            string strFileContent = sreader.ReadToEnd(); 
            string[] words = strFileContent.Split(new char[] { ' ', '\r', '\n', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
          
            
            List<string> keywords = new List<string> { "id","set","return","Id","EventHandler<EventArgs>","eventhandler","event","collections","system","abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", " throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "using", "static", "virtual", "void", "volatile", "while" };
            var ikeywords = words.Select(i => i.ToString()).Intersect(keywords).ToList();
            int result = 0;
            foreach (string ew in ikeywords)
            {
                
                result = result + 1;
                Console.WriteLine(ew + Environment.NewLine);
            }
            Console.WriteLine($"total number of keywords in program file is:{result}");
        }
        public static int CountLines(string filepath)
        {
            StreamReader sreader = new StreamReader(filepath);
            string strFileContent = sreader.ReadToEnd(); //Read all the content
            string[] words = strFileContent.Split(new char[] { ' ', '\r', '\n', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
            //Split by words and remove new lines empty entries
            sreader.Close();
            var lineCount = File.ReadAllLines(filepath).Count(line => !string.IsNullOrWhiteSpace(line));
            
            return lineCount;
        }
        public static string DeleteComments(string filename)
        {
            
            Regex comments1 = new Regex(@"//.*?\n",RegexOptions.Multiline);
            Regex comments2 = new Regex(@"\s*/\*.*? \*/\s*",RegexOptions.Singleline);
  
            string all_text = File.ReadAllText(filename);
            string afterRemoval = comments1.Replace(all_text, " ");
            afterRemoval = comments2.Replace(afterRemoval, " ");
            
            return afterRemoval;
            
        }
    }
    }
