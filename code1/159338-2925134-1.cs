    [XmlType("EMPLOYEES"), Serializable]
    public class Employees {
       public Employee[] employee {get; set;}
    }
    [XmlType("EMPLOYEE")]
    public class Employee {
       [XmlAttribute("isBestEmployee")]
       public bool bestEmployee {get; set;}
       [XmlText]
       public string name;
    }
