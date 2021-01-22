        public class Customer
        {
        private readonly string m_name;
        private readonly int m_age;
    
        public Customer(string name, int age)
        {
            m_name = name;
            m_age = age;
        }
    
        public string Name
        {
            get { return m_name; }
        }
    
        public int Age
        {
            get { return m_age; }
        }
      }
