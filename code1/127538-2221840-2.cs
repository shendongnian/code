    class Demo
    {
      static void Main()
      {
        string s = "Hello!";
        List<Employee> payroll = new List<Employee>();
    
        for each (var item in s)
        {
          Console.WriteLine(item);
        }
    
        for each (var item in payroll)
        {
          Console.WriteLine(item);
        }
    }
