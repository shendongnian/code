    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = "cd69ef0284bba33bc0b320e6479c2da2d411a5e46af060d8639f0e0bfc24f26d";
            byte[] data = ParseHex(text);
            Console.WriteLine(Convert.ToBase64String(data));
        }
        
        // Taken from https://stackoverflow.com/questions/795027/code-golf-hex-to-raw-binary-conversion/795036#795036
        static byte[] ParseHex(string text)
        {
            Func<char, int> parseNybble = c => (c >= '0' && c <= '9') ? c-'0' : char.ToLower(c)-'a'+10;
            return Enumerable.Range(0, text.Length/2)
                .Select(x => (byte) ((parseNybble(text[x*2]) << 4) | parseNybble(text[x*2+1])))
                .ToArray();
        }
    }
