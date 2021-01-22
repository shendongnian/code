    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace App
    {
        class Program
        {
            static void Main(string[] args)
            {
                var doc = XDocument.Parse("<a><b>this</b><b><c>is</c><c><d>a test</d></c></b></a>");
    
                var textNodes = doc
                    .DescendantNodes()
                    .Where(node => node.NodeType == System.Xml.XmlNodeType.Text);
    
                foreach (XText textNode in textNodes)
                    textNode.Value = Scramble(textNode.Value);
    
                Console.WriteLine(doc.ToString());
    
                foreach (XText textNode in textNodes)
                    textNode.Value = UnScramble(textNode.Value);
    
                Console.WriteLine(doc.ToString());
                Console.ReadLine();
            }
    
            public static string Scramble(string s)
            {
                var a = s.Select(ch => ch != ' ' ? (char) (ch + 3) : ' ').ToArray();
                return new string(a);
            }
    
            public static string UnScramble(string s)
            {
                var a = s.Select(ch => ch != ' ' ? (char)(ch - 3) : ' ').ToArray();
                return new string(a);
            }
        }
    }
