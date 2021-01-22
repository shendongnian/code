    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            var companiesWithEmployees = new List<CompanyWithEmployees>()
            {                
                new CompanyWithEmployees
                {                 
                    CompanyInfo = new Company { CompanyName = "Buen" },
                    Employees = new List<Person>() 
                    { 
                        new Person { PersonID = 1976, PersonName = "Michael" },
                        new Person { PersonID = 1982, PersonName = "Mark" },
                        new Person { PersonID = 1985, PersonName = "Matthew" },                            
                        new Person { PersonID = 1988, PersonName = "Morris" }
                    }
                },
 
                new CompanyWithEmployees
                {
                    CompanyInfo = new Company { CompanyName = "Muhlach" },
                    Employees = new List<Person>()
                    {
                        new Person { PersonID = 1969, PersonName = "Aga" },
                        new Person { PersonID = 1971, PersonName = "Nino" },
                        new Person { PersonID = 1996, PersonName = "Mark" }
                    }
                },
                new CompanyWithEmployees
                {
                    CompanyInfo = new Company { CompanyName = "Eigenmann" },
                    Employees = new List<Person>()
                    {
                        new Person { PersonID = 1956, PersonName = "Michael" },                        
                        new Person { PersonID = 1999, PersonName = "Gabby" }
                    }
                }
            };
            // just explicitly declared the types (instead of var) so the intent is more obvious
            IEnumerable<CompanyWithEmployees> whereAreMichaels = 
                  companiesWithEmployees.Where(cx => cx.Employees.Any(px => px.PersonName == "Michael"));
            string michaelsCompanies = 
                  string.Join(", ", whereAreMichaels.Select(cx => cx.CompanyInfo.CompanyName).ToArray());
            MessageBox.Show("Company(s) with employee Michael : " + michaelsCompanies);
            Person findAga = companiesWithEmployees
                                  .Find(company => company.CompanyInfo.CompanyName == "Muhlach")
                                  .Employees.Find(person => person.PersonName == "Aga");
            if (findAga != null)
                MessageBox.Show("Aga's ID : " + findAga.PersonID.ToString());
            
        }
    }
    class CompanyWithEmployees
    {
        public CompanyWithEmployees() { }
        public Company CompanyInfo { get; set; }
        public List<Person> Employees { get; set; }
    }
    class Company
    {
        public string CompanyName { get; set; }
    }
    class Person
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
    }
