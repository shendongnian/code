    public class Service
    {
        public Service()
        {
        }
        public void DoSomething()
        {
            SqlConnection connection = new SqlConnection("some connection string");
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            // Do something with connection and identity variables
        }
    }
