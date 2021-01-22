    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;  // NOTE: add reference to Microsoft.VisualBasic
    
    class Program {
        static void Main(string[] args) {
            var strm = new StringReader("John Doe        New York  Test Comment");
            var parse = new TextFieldParser(strm);
            parse.TextFieldType = FieldType.FixedWidth;
            parse.SetFieldWidths(16, 10, 12);
            foreach (var field in parse.ReadFields())
                Console.WriteLine(field.Trim());
            Console.ReadLine();
        }
    }
