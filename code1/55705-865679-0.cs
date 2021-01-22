    using System;
    using System.IO;
    using System.Text;
    
    public static class Extensions
    {
        public static string ReadWord(this TextReader reader)
        {
            StringBuilder builder = new StringBuilder();
            int c;
            
            // Ignore any trailing whitespace from previous reads            
            while ((c = reader.Read()) != -1)
            {
                if (!char.IsWhiteSpace((char) c))
                {
                    break;
                }
            }
            // Finished?
            if (c == -1)
            {
                return null;
            }
            
            builder.Append((char) c);
            while ((c = reader.Read()) != -1)
            {
                if (char.IsWhiteSpace((char) c))
                {
                    break;
                }
                builder.Append((char) c);
            }
            return builder.ToString();
        }
    }
    
    public class Test
    {
        static void Main()
        {
            // Give it a few challenges :)
            string data = @"Four score     and
                               
    seven years ago    ";
    
            using (TextReader reader = new StringReader(data))
            {
                string word;
                
                while ((word = reader.ReadWord()) != null)
                {
                    Console.WriteLine("'{0}'", word);
                }
            }
        }
    }
