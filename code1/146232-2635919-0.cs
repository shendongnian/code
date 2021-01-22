    public abstract class CustomerServiceDesk
    {
        public delegate void ElevateQueryEventHandler(Customer c);
        public event ElevateQueryEventHandler OnElevateQuery;
        public abstract void ServeCustomer(Customer c);
    }
    public class FrontLineServiceDesk : CustomerServiceDesk
    {
        public override void ServeCustomer(Customer c)
        {
            switch (c.ComplaintType)
            {
                case ComplaintType.General:
                    Console.WriteLine(c.Name + " Complaints are registered; will be served soon by FrontLine Help Desk");
                    break;
                default:
                    OnElevateQuery(c);
            }
        }
    }
    public class CriticalIssueServiceDesk : CustomerServiceDesk
    {
        public override void ServeCustomer(Customer c)
        {
            switch (c.ComplaintType)
            {
                case ComplaintType.Critical:
                    Console.WriteLine(c.Name + " Complaints are registered; will be served soon by Critical Help Desk");
                    break;
                case ComplaintType.Legal:
                    OnElevateQuery(c);
                    break;
                default:
                    Console.WriteLine("Unable to find appropriate help desk for your complaint.");
                    break;
            }
        }
    }
    public class LegalIssueServiceDesk : CustomerServiceDesk
    {
        public override void ServeCustomer(Customer c)
        {
            if (c.CompliantType == CompliantType.Legal)
            {
                Console.WriteLine(c.Name + " Complaints are registered; will be served soon by Legal Help Desk");
            }
            else
            {
                // you could even hook up the FrontLine.ServeCustomer event 
                // to the OnElevateQuery event of this one so it takes the 
                // query back to the start of the chain (if it accidently ended up here).
                Console.WriteLine("Wrong department");
            }
        }
    }
