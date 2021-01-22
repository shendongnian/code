    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class Program
    {
        public static void Main()
        {
            try
            {
                var badString = "ABC\\DEF/GHI<JKL>MNO:PQR\"STU\tVWX|YZA*BCD?EFG";
                Console.WriteLine(badString);
                Console.WriteLine(SanitizeFileName(badString, '.'));
                Console.WriteLine(SanitizeFileName(badString));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static string SanitizeFileName(string fileName, char? replacement = null)
        {
            if (fileName == null) { return null; }
            if (fileName.Length == 0) { return ""; }
            var sb = new StringBuilder();
            var badChars = Path.GetInvalidFileNameChars().ToList();
            foreach (var @char in fileName)
            {
                if (badChars.Contains(@char)) 
                {
                    if (replacement.HasValue)
                    {
                        sb.Append(replacement.Value);
                    }
                    continue; 
                }
                sb.Append(@char);
            }
            return sb.ToString();
        }
    }
