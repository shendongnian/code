    using System.Xml.Linq;
    using System.Linq;
    class Program
    {
        public static string FindStudent(XDocument xDoc, string id)
        {
            //this gets the list of Student elements in the document
            var students = xDoc.Elements().First().Elements("Student");
            //this gets the one with the requested id
            //throws an 'InvalidOperationException' if 0 OR more than 1 element found
            var studentById = students.Single(c => c.Element("IDstudent").Value == id);
            
            //return a string that you already are able to transform into a Student object??
            return studentById.ToString();  
        }
        static void Main(string[] args)
        {
            //Load into an xDocument from file
            XDocument xDoc = XDocument.Load(@"Path\To\Test.xml");
            Console.WriteLine(FindStudent(xDoc, "3"));
            Console.ReadLine();
        }
    }
