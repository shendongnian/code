    using System;
    
    class Test
    {
        static void Main()
        {
            CheckTrim(string.Copy(""));
            CheckTrim("  ");
            CheckTrim(" x ");
            CheckTrim("xx");
        }
    
        static void CheckTrim(string text)
        {
            string trimmed = text.Trim();
            Console.WriteLine ("Text: '{0}'", text);
            Console.WriteLine ("Trimmed ref == text? {0}",
                              object.ReferenceEquals(text, trimmed));
            Console.WriteLine ("Trimmed ref == \"\"? {0}",
                              object.ReferenceEquals("", trimmed));
            Console.WriteLine();
        }
    }
