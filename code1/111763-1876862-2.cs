    class Program
    {
        static void Main(string[] args)
        {
            string s = @"stuff <td class=""blah"" ...........>Some text blah: page 13 of 99<br> more stuff";
            Match match = Regex.Match(s, @"<td[^>]*\sclass=""blah""[^>]*>[^<]*page \d+ of (\d+)<br>");
    
            if (match.Success)
            {
                Console.WriteLine(match.Groups[1].Value);
            }
        }
    }
