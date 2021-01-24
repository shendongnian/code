    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^T\d{10}\D";
            var re = new Regex(pattern);
    
            var result = new List<string>();
            var block = new StringBuilder();
            var fileStream = new FileStream(@"c:\file.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (re.IsMatch(line))
                    {
                        //store current block or hand it off to different process, etc.
                        result.Add(block.ToString());
                        block.Clear();
                    }
                    block.AppendLine(line);
                }
                // final block
                result.Add(block.ToString());
            }
        }
    }
