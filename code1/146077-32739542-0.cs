    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    
    namespace LinqToXML
    {
        class Program
        {
            static void Main(string[] args)
            {
                int ch;
                do
                {
                    Console.WriteLine("Enter the operation you want to execute");
    
                    Console.WriteLine("Press 1 to show previous record");
                    Console.WriteLine("Press 2 to add new record");
                    Console.WriteLine("Press 3 to delete record");
                    Console.WriteLine("Press 4 to update record");
    
                    Record RecordObject = new Record();
    
                    int UserChoice = Convert.ToInt32(Console.ReadLine());
    
                    switch (UserChoice)
                    {
                        case 1:
                            RecordObject.ShowRecord();
    
                            break;
    
                        case 2:
                            RecordObject.AddRecord();
    
                            break;
    
                        case 3:
                            RecordObject.DeleteRecord();
    
                            break;
    
                        case 4:
                            RecordObject.UpdateRecord();
    
                            break;
    
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
    
                    Console.WriteLine("\tDo you Want to CONTINUE?\n\t1.YES\n\t2.NO");
                    ch = Convert.ToInt32(Console.ReadLine());
                } while (ch == 1);
            }
        }
    
        class Info
        {
            public string StudentName { get; set; }
            public int StudentId { get; set; }
            public int StudentAge { get; set; }
            public string StudentCity { get; set; }
        }
    
        class Record
        {
            string fileAddress = @"C:\XML.xml";
            XmlDocument doc = new XmlDocument();
    
            public void ShowRecord()
            {
                if (File.Exists(fileAddress))
                {
                    string line;
                    using (StreamReader sr = new StreamReader(fileAddress))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("No record exist");
                }
            }
    
            public void AddRecord()
            {
                Console.WriteLine("Enter Student Name :");
                string StuName = Console.ReadLine();
    
                Console.WriteLine("Enter Student Age :");
                int StuAge = Convert.ToInt32(Console.ReadLine());
    
                Console.WriteLine("Enter Student City :");
                string StuCity = Console.ReadLine();
    
                Info InfoObj = new Info();
    
                InfoObj.StudentName = StuName;
                InfoObj.StudentAge = StuAge;
                InfoObj.StudentCity = StuCity;
    
    
                FileStream FileStreamObj = null;
    
                if (File.Exists(fileAddress))
                {
                    FileStreamObj = new FileStream(fileAddress, FileMode.Open, FileAccess.ReadWrite);
                    FileStreamObj.Close();
    
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileAddress);
    
                    XmlNodeList nodes = doc.SelectNodes("//students/student");
                    int nodeCount = nodes.Count;
                    nodeCount++;
    
    
                    XmlNodeList students = doc.SelectNodes("//students");
                    foreach (XmlNode student in students)
                    {
    
                        XmlNode parentNode = doc.CreateElement("student");
    
                        XmlAttribute attribute = doc.CreateAttribute("id");
                        attribute.Value = nodeCount.ToString();
                        parentNode.Attributes.Append(attribute);
                        student.AppendChild(parentNode);
    
                        XmlNode studentName = doc.CreateElement("studentName");
                        studentName.InnerText = StuName;
                        parentNode.AppendChild(studentName);
    
                        XmlNode studentAge = doc.CreateElement("studentAge");
                        studentAge.InnerText = StuAge.ToString();
                        parentNode.AppendChild(studentAge);
    
                        XmlNode studentCity = doc.CreateElement("studentCity");
                        studentCity.InnerText = StuCity;
                        parentNode.AppendChild(studentCity);
    
                        doc.Save(fileAddress);
    
                    }
                }
                else
                {
                    FileStreamObj = new FileStream(fileAddress, FileMode.Create, FileAccess.ReadWrite);
                    FileStreamObj.Close();
    
                    int StudentId = 1;
    
                    XmlDocument doc = new XmlDocument();
    
                    XmlNode rootNode = doc.CreateElement("students");
                    doc.AppendChild(rootNode);
    
                    XmlNode parentNode = doc.CreateElement("student");
                    XmlAttribute attribute = doc.CreateAttribute("id");
                    attribute.Value = StudentId.ToString();
                    parentNode.Attributes.Append(attribute);
                    rootNode.AppendChild(parentNode);
    
                    XmlNode studentName = doc.CreateElement("studentName");
                    studentName.InnerText = StuName;
                    parentNode.AppendChild(studentName);
    
                    XmlNode studentAge = doc.CreateElement("studentAge");
                    studentAge.InnerText = StuAge.ToString();
                    parentNode.AppendChild(studentAge);
    
                    XmlNode studentCity = doc.CreateElement("studentCity");
                    studentCity.InnerText = StuCity;
                    parentNode.AppendChild(studentCity);
    
                    doc.Save(fileAddress);
                }
            }
    
            public void UpdateRecord()
            {
                doc.Load(fileAddress);
                Console.WriteLine("Enter ID of the record you want to update");
                int InputChoice = Convert.ToInt32(Console.ReadLine());
    
                Info infoObj = new Info();
    
                XmlElement element = doc.DocumentElement;
                XmlNode nodeElement = element.SelectSingleNode("student[@id='" + InputChoice + "']");
    
                if (nodeElement == null)
                {
                    Console.WriteLine("Record doesn't exist");
                }
                else
                {
                    string oldName = nodeElement.ChildNodes[0].InnerText;
                    string oldAge = nodeElement.ChildNodes[1].InnerText;
                    string oldCity = nodeElement.ChildNodes[2].InnerText;
    
                    infoObj.StudentName = oldName;
                    infoObj.StudentAge = Convert.ToInt32(oldAge);
                    infoObj.StudentCity = oldCity;
    
                    Console.WriteLine("Old Values are:\n\tName: " + infoObj.StudentName + "\n\tAge" + infoObj.StudentAge + " \n\tCity" + infoObj.StudentCity + "");
    
                    Console.WriteLine("Enter new name");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Enter new Age");
                    int newAge = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter new city");
                    string newCity = Console.ReadLine();
    
                    infoObj.StudentName = newName;
                    infoObj.StudentAge = newAge;
                    infoObj.StudentCity = newCity;
    
                    nodeElement.ChildNodes[0].InnerText = infoObj.StudentName;
                    nodeElement.ChildNodes[1].InnerText = infoObj.StudentAge.ToString();
                    nodeElement.ChildNodes[2].InnerText = infoObj.StudentCity;
    
                    doc.Save(fileAddress);
                }
            }
    
            public void DeleteRecord()
            {
                doc.Load(fileAddress);
    
                Console.WriteLine("Enter the Id you want to delete");
                string inputValue = Console.ReadLine();
    
                XmlElement element = doc.DocumentElement;
                XmlNode nodeElement = element.SelectSingleNode("student[@id='" + inputValue + "']");
                if (nodeElement == null)
                {
                    Console.WriteLine("Record doesn't exist");
                }
                else
                {
                    element.RemoveChild(nodeElement);
                    doc.Save(fileAddress);
                    Console.WriteLine("Sucessfully deleted");
                }
    
            }
        }
    
    }
