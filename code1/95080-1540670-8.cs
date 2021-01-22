    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    
    namespace App
    {
        class Scrambler
        {
            public static void ScrambleTextNodes(XContainer xml)
            {
                foreach (XText textNode in GetDescendantTextNodes(xml))
                    textNode.Value = Scramble(textNode.Value);
            }
    
            public static void UnScrambleTextNodes(XContainer xml)
            {
    
                foreach (XText textNode in GetDescendantTextNodes(xml))
                    textNode.Value = UnScramble(textNode.Value);
            }
    
            public static IEnumerable<XNode> GetDescendantTextNodes(XContainer xml)
            {
                return xml.DescendantNodes().Where(node => node.NodeType == System.Xml.XmlNodeType.Text);
            }
    
            public static string Scramble(string s)
            {
                var a = s.Select(ch => (char)(ch + 3)).ToArray();
                return new string(a);
            }
    
            public static string UnScramble(string s)
            {
                var a = s.Select(ch => (char)(ch - 3)).ToArray();
                return new string(a);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var doc = XDocument.Parse("<a><b>this</b><b><c>is</c><c><d>a test</d></c></b></a>");
    
                Scrambler.ScrambleTextNodes(doc);
    
                Console.WriteLine(doc.ToString());
    
                Scrambler.UnScrambleTextNodes(doc);
    
                Console.WriteLine(doc.ToString());
    
                Console.ReadLine();
            }
            
        }
    }
