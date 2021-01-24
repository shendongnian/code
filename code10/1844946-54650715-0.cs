    public class Employee
    {
        public string knownas { get; set; }
        public string userName { get; set; }
    }
    public void Test()
    {
        List<Employee> employess = new List<Employee>();
        string searchvalue = "test";
        var listEmplyer = employess.Where(x => (x.userName + x.knownas).Contains(searchvalue));
    }
