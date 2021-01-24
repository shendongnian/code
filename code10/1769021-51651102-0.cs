    using System;
    using System.Xml.Linq;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var xml = @"
    <grading>
      <leap>
        <controlId>1</controlId>
      </leap>
      <controlId>2</controlId>
    </grading>";
            
            XDocument doc = XDocument.Parse(xml);
            XElement control = doc.Root.Element("controlId");
            Console.WriteLine(control.Value); // 2
        }
    }
