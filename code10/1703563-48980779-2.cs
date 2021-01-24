    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    
    namespace ConsoleApp1
    {
        internal static class Program
        {
            private const string Text = @"<?xml version=""1.0""?>
    <catalog>
       <book id=""bk101"">
          <author>Gambardella, Matthew</author>
          <title>XML Developer's Guide</title>
          <genre>Computer</genre>
          <price>44.95</price>
          <publish_date>2000-10-01</publish_date>
          <description>An in-depth <chk att=""sdf1"">A-list</chk>, <chk att=""sdf2"">B-list</chk>, <chk att=""sdf3"">X-list</chk> look at creating applications 
          with XML.</description>
       </book>
       <book id=""bk102"">
          <author>Ralls, Kim</author>
          <title>Midnight Rain</title>
          <genre>Fantasy</genre>
          <price>5.95</price>
          <publish_date>2000-12-16</publish_date>
          <description>A former <chk att=""sdf14"">lA-list</chk>, <chk att=""sdf16"">pB-list</chk>, <chk att=""sdf3"">sX-list</chk> architect battles corporate zombies, 
          an evil sorceress, and her own childhood to become queen 
          of the world.</description>
       </book>
       <book id=""bk103"">
          <author>Corets, Eva</author>
          <title>Maeve Ascendant</title>
          <genre>Fantasy</genre>
          <price>5.95</price>
          <publish_date>2000-11-17</publish_date>
          <description>After the collapse <chk att=""sdf11"">A-list</chk>, <chk att=""sdf20"">B-list</chk>, <chk att=""sdf21"">X-list</chk>, <chk att=""sdf22"">A-list</chk>, <chk att=""sdf23"">B-list</chk>, <chk att=""sdf25"">X-list</chk> of a nanotechnology 
          society in England, the young survivors lay the 
          foundation for a new society.</description>
       </book>
    </catalog>
    ";
    
            private static void Main(string[] args)
            {
                var document = XDocument.Parse(Text);
    
                var books = document.Element("catalog").Elements("book");
    
                foreach (var book in books)
                {
                    var attributes = book.Element("description").Elements("chk").Attributes("att");
    
                    var values = attributes.Select(s => int.Parse(Regex.Match(s.Value, @"\d+").Value)).ToArray();
    
                    var first = values.First();
                    var last = values.Last();
                    var sum = Enumerable.Range(first, Math.Max(0, last - first + 1)).ToArray().Sum();
    
                    var consecutive = values.Sum() == sum;
    
                    Console.WriteLine(consecutive);
                }
            }
        }
    }
