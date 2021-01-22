    public abstract class CustomerServiceDesk
    {
        protected CustomerServiceDesk()
        {
            ServeCustomers = doServeCustomers;
        }
        protected CustomerServiceDesk m_ServiceDesk = null;
        protected abstract void doServeCustomers(Customer _customer);
        public delegate void ServeCustomersDelegate(Customer _customer);
        public ServeCustomersDelegate ServeCustomers = null;
    }
    public class LegalissueServiceDesk : CustomerServiceDesk
    {
        public LegalissueServiceDesk()
        {
        }
        protected override void doServeCustomers(Customer _customer)
        {
            if (_customer.ComplaintType == ComplaintType.Legal)
            {
                Console.WriteLine(_customer.Name + " - Complaints are registered  ; will be served soon by legal help desk.\n");
            }
        }
    }
    public class CriticalIssueServiceDesk : CustomerServiceDesk
    {
        public CriticalIssueServiceDesk()
        {
            m_ServiceDesk = new LegalissueServiceDesk();
            ServeCustomers += m_ServiceDesk.ServeCustomers;
        }
        protected override void doServeCustomers(Customer _customer)
        {
            if (_customer.ComplaintType == ComplaintType.Critical)
            {
                Console.WriteLine(_customer.Name + " - Complaints are registered  ; will be served soon by Critical Help Desk.\n");
            }
        }
    }
    public class FrontLineServiceDesk : CustomerServiceDesk
    {
        public FrontLineServiceDesk()
        {
            m_ServiceDesk = new CriticalIssueServiceDesk();
            ServeCustomers += m_ServiceDesk.ServeCustomers;
        }
        protected override void doServeCustomers(Customer _customer)
        {
            if (_customer.ComplaintType == ComplaintType.General)
            {
                Console.WriteLine(_customer.Name + " - Complaints are registered  ; will be served soon by FrontLine Help Desk.\n");
            }
        }
    }
    public class Customer
    {
        public string Name;
        public ComplaintType ComplaintType;
    }
    public enum ComplaintType
    {
        General,
        Critical,
        Legal
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer _customer1 = new Customer();
            _customer1.Name = "Microsoft";
            _customer1.ComplaintType = ComplaintType.General;
            Customer _customer2 = new Customer();
            _customer2.Name = "SunSystems";
            _customer2.ComplaintType = ComplaintType.Critical;
            Customer _customer3 = new Customer();
            _customer3.Name = "HP";
            _customer3.ComplaintType = ComplaintType.Legal;
            FrontLineServiceDesk _frontLineDesk = new FrontLineServiceDesk();
            _frontLineDesk.ServeCustomers(_customer1);
            _frontLineDesk.ServeCustomers(_customer2);
            _frontLineDesk.ServeCustomers(_customer3);
            Console.In.ReadLine();
        }
    }
