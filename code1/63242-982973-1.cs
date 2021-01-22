    public class Employee : IChildItem<Company>
    {
        [XmlIgnore]
        public Company Company { get; private set; }
        #region IChildItem<Company> explicit implementation
        Company IChildItem<Company>.Parent
        {
            get
            {
                return this.Company;
            }
            set
            {
                this.Company = value;
            }
        }
        #endregion
    }
    public class Company
    {
        public Company()
        {
            this.Employees = new ChildItemCollection<Company, Employee>(this);
        }
        public ChildItemCollection<Company, Employee> Employees { get; private set; }
    }
