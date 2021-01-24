    var person = new Employee()
                { 
                    Name = "Mark Zuckerberg",
                    Salary = 1000
                };
    
    var bf = new BinaryFormatter();
    bf.Serialize(new FileStream("C:\\TEMP\\test.dat", FileMode.Create), person);
   
    [Serializable]
    public class Employee
    {
      public string Name { get; set; }
      public decimal Salary { get; set; }
    }
