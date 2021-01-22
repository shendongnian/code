     public class Customer
    {
        private int customerId = 0;
        public int CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }
        public List<Project> availableProjects
        {
            get
            {
                return getCustomerRelatedProjects();
            }
        }
        //you change the accessor here according to the needs
        private List<Project> getCustomerRelatedProjects()
        {
            //do the processing here for Database hit or from the list you load at the program load etc.
            return new List<Project>();
        }
    }
