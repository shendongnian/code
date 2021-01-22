    class ClassA
    {
        private ClassB m_ClassB = null;
        public ClassB B
        {
            get
            {
                //check if we already have an instance of the class.
                //if not create it
                if (m_ClassB == null)
                {
                    m_ClassB = new ClassB();
                }
                return m_ClassB;
            }
        }
    }
    class ClassB
    {
        private ClassC m_ClassC = null;
        public ClassC C
        {
            get
            {
                //check if we already have an instance of the class.
                //if not create it
                if (m_ClassC == null)
                {
                    m_ClassC = new ClassC();
                }
                return m_ClassC;
            }
        }
    }
    class ClassC
    {
        private int m_Id = 123;
        public int ID
        {
            get
            {
                return m_Id;
            }
        }
    }
