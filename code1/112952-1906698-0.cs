    class Program
    {
        static void Main() 
        {
            string s = @"/Pages 2 0 R/Type /Catalog/AcroForm
    /Count 1 /Kids [3 0 R]/Type /Pages
    /Filter /FlateDecode/Length 84";
    
            var regex = new Regex(@"[\/]([^\s^\/]*)[\s]");
            foreach (Match item in regex.Matches(s))
            {
                Console.WriteLine(item.Groups[1].Value);
            }
    
        }
    }
