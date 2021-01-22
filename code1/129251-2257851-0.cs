    [XmlRoot("ROWSET")]
    public class Department
    {
        [XmlElement("ROW")]
        public Row[] Rows { get; set; }
    }
    public class Row
    {
        [XmlElement("DEPARTMENT_ID")]
        public string DepID { set; get; }
        [XmlElement("DEPARTMENT_NAME")]
        public string DepName { set; get; }
        [XmlElement("EMPLOYEES")]
        public Employee[] Employees { set; get; }
    }
    public class Employee
    {
        [XmlElement("EMP_ID")]
        public string EmpID { set; get; }
        [XmlElement("EMP_NAME")]
        public string EmpName { set; get; }
    }
    class Program
    {
        static void Main()
        {
            var dep = new Department
            {
                Rows = new[] 
                {
                    new Row 
                    {
                        DepID = "1",
                        DepName = "Sales",
                        Employees = new[] 
                        {
                            new Employee 
                            {
                                EmpID = "12",
                                EmpName = "Fred"
                            },
                            new Employee 
                            {
                                EmpID = "13",
                                EmpName = "Hohn"
                            }
                        }
                    },
                    new Row 
                    {
                        DepID = "2",
                        DepName = "Marketing",
                    }
                }
            };
            var serializer = new XmlSerializer(dep.GetType());
            serializer.Serialize(Console.Out, dep);
        }
