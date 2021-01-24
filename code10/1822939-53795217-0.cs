    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ConsoleApp5
    {
        class Program
        {
            static void Main(string[] args)
            {
                string contacts = @"contacts.csv";
                string content = @"content.csv";
                string[] delimiter = { "£&%" };
                string read_contents;
    
                using (StreamReader streamReader = new StreamReader(content, Encoding.UTF8))
                    read_contents = streamReader.ReadToEnd();
    
                string sar_contacts = File.ReadAllText(contacts);
                List<string> contactsToReplace = sar_contacts.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();
    
                int i = 0;
                foreach (var wordToCensor in contactsToReplace)
                {
                    read_contents = Strings.Replace(read_contents, wordToCensor, "######", 1, -1, Constants.vbTextCompare);
                    Console.WriteLine(++i); // so we know where we are
                }
    
                File.WriteAllText(@"filtered.csv", read_contents);
            }
        }
    }
