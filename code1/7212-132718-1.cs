        public class Customer
        {
        private string m_name;
        private int m_age;
    
        protected Customer() 
        {}
        public Customer(string name, int age)
        {
            m_name = name;
            m_age = age;
        }
    
        public string Name
        {
            get { return m_name; }
            protected set { m_name = value; }
        }
    
        public int Age
        {
            get { return m_age; }
            protected set { m_age = value; }
        }
      }
