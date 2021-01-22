    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new DataContractSerializer(typeof(Employee));
    
            var employee = new Employee() { Name="Joe" };
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, employee);
    
                ms.Flush();
                ms.Position = 0;
    
                var newE = serializer.ReadObject(ms) as Employee;
            }
    
            Console.ReadKey();
            
        }
    }
    [DataContract]
    public class Employee
    {
        private string _name;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
