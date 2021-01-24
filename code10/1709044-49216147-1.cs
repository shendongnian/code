    using HtmlAgilityPack;
    using System;
    
    namespace WordCounter
    {
        class Program
        {
            private static readonly Uri Uri = new Uri("https://www.w3schools.com/html/html_editors.asp");
    
            static void Main(string[] args)
            {
                var doc = new HtmlWeb().Load(Uri);
                var nodes = doc.DocumentNode.SelectSingleNode("//body").DescendantsAndSelf();
                var word = Console.ReadLine().ToLower();
                while (word != "exit")
                {
                    var count = 0;
                    foreach (var node in nodes)
                    {
                        if (node.NodeType == HtmlNodeType.Text && node.ParentNode.Name != "script" && node.InnerText.ToLower().Contains(word))
                        {
                            count++;
                        }
                    }
    
                    Console.WriteLine($"{word} is displayed {count} times.");
                    word = Console.ReadLine().ToLower();
                }
            }
        }
    }
