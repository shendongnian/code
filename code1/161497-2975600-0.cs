    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MyClass
    {
        public static void Main()
        {
            //read relevant text from disk
            string AllText = File.ReadAllText(@"c:\alltext.txt"); 
            string Contents = File.ReadAllText(@"c:\contents.txt");
            string text = "TEXT";
            int line = SearchForLine(AllText, Contents, text);
            
            Console.WriteLine(line);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        static int SearchForLine(string AllText, string Contents, string SearchText)
        {
            //split strings into arrays based on newline character 
            //uses environment.newline (\r\n on windows). change to what you 
            //need if this isn't correct
            string[] AllTextSplit = SplitStringOnNewLine(AllText);
            string[] ContentsSplit = SplitStringOnNewLine(Contents);
            
            //find the first line of Contents in AllText 
            int start = FindIndex(AllTextSplit, ContentsSplit[0]);
            //find the last line of Contents in AllText 
            int stop = FindIndex(AllTextSplit, ContentsSplit[ContentsSplit.Length - 1]);
            //search alltext for SearchText between start and stop (lines where contents exist in AllText
            for (int i = start; i <= stop; i++)
            {
                if (AllTextSplit[i].IndexOf(SearchText)!=-1)
                {
                    return i + 1; // + 1 because you want line numbers starting at 1   
                }
            }
           return -1; 
        }
        private static int FindIndex(string[] TextToSearch, string SearchText)
        {
            for (int i = 0; i < TextToSearch.Length; i++)
            {
                if (TextToSearch[i] == SearchText)
                {
                    return i;
                }
            }
            return -1;
        }
        private static string[] SplitStringOnNewLine(string StringToSplit)
        {
            return StringToSplit.Split(new string[] { Environment.NewLine },
                           StringSplitOptions.None);
        }
    }
