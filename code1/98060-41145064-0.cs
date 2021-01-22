    using System;
    interface IName
    {
        string Name { get; set; }
    }
    class Employee : IName
    {
        public string Name { get; set; }
    }
    class Company : IName
    {
        private string _company { get; set; }
        public string Name
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }   
        }
    }
    class Client
    {
        static void Main(string[] args)
        {
            IName e = new Employee();
            e.Name = "Tim Bridges";
            IName c = new Company();
            c.Name = "Inforsoft";
            Console.WriteLine("{0} from {1}.", e.Name, c.Name);
            Console.ReadKey();
        }
    }
    /*output:
     Tim Bridges from Inforsoft.
     */
