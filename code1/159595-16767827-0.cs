    class MyClass
    {
        ...
        List<MyOtherClass> m_Things = new List<MyOtherClass>();
        public List<MyOtherClass> Things
        {
            get
            {
                if (ThingsForLinq != null)
                {
                    m_Things = ThingsForLinq.ToList();
                    ThingsForLinq = null;
                }
                return m_Things;
            }
            set
            {
                m_Things = value;
            }
        }
        IEnumerable<MyOtherClass> ThingsForLinq { get; set; }
    }
