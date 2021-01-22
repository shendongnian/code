    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace Module2
    {
        public class Archives
        {
            public void readArchive()
            {
                //this will read from the archive
                StreamReader SR;
                string S;
                int i = 0;
                SR = File.OpenText(@"the path here for the excel archive");
    
                S = SR.ReadToEnd();
                SR.Close();
                Console.WriteLine(S);
                string[] words = S.Split(';');
                Array.Sort(words);
                for (i = 0; i < words.Length; i++)
                    Console.WriteLine(words[i]);
    
                //this will create the archive
                StreamWriter SW;
                SW = File.CreateText(@"the path here for the .txt");
                for (i = 0; i < words.Length; i++)
                    SW.WriteLine(words[i]);
                SW.Close();
            }
        }
    }
