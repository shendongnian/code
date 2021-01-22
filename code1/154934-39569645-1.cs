    namespace Marcus
    {
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Startup
        {
            public static void Main()
            {
                Employee e = new Employee();
                e = null;
    
                string s = e.ToString(); // This will throw an null exception
                s = Convert.ToString(e); // This will throw null exception but it will be automatically handled by Convert.ToString() and exception will not be shown on command window.
            }
        }
    }
