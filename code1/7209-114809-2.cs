    public interface IReadOnlyCustomer
    {
        String Name { get; }
        int Age { get; }
    }
    public class Customer : IReadOnlyCustomer
    {
        private string m_name;
        private int m_age;
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public int Age
        {
            get { return m_age; }
            set { m_age = value; }
        }
    }
