    using System;
    using System.Xml.Linq;
    
    namespace StackOverflow
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var xml = XElement.Parse(@"
    <root>
        <Resources>
            <a>123.png</a>
        </Resources>
        <Resources>
            <b>123.png</b>
        </Resources>
        <Resources>
            <c>123.png</c>
        </Resources>
    </root>");
    
                var resourceElements = xml.Elements("Resources");
                foreach (var resourceElement in resourceElements)
                {
                    // Convert from XNode to XElement
                    var desiredElement = resourceElement.FirstNode as XElement; 
                    var elementName = desiredElement.Name;
                    Console.WriteLine(elementName);
                }
                Console.ReadLine();
            }
        }
    }
