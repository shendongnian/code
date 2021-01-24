    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                ParseXml(xml);
      
            }
            public static void ParseXml(string xml)
            {
                XDocument xdoc = XDocument.Parse(xml);
                List<Employee> employees = xdoc.Descendants("Employee").Select(x => new Employee () {
                    id = (int)x.Element("Id"),
                    name = (string)x.Element("Name"),
                    Department = x.Elements("Department").Select(y => new Department() { DeptId = (int)y.Element("DeptId"), DeptName = (string)y.Element("DeptName")}).FirstOrDefault(),
                    Dependents = x.Descendants("Dependent").Select(y => new Dependents() { age = (int)y.Element("age"),  name = (string)y.Element("name")}).ToList()
                }).ToList();
            }
     
        }
        public class Employee
        {
            public int id { get; set; }
            public string name { get; set; }
            public List<Dependents> Dependents { get; set; }
            public Department Department { get; set; }
        }
        public class Dependents
        {
            public string name { get; set; }
            public int age { get; set; }
        }
        public class Department
        {
            public int DeptId { get; set; }
            public string DeptName { get; set; }
        }
    }
