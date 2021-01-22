    class B
    {
        private A m_a = new A();
        
        public event EventType EventB
        {
            add { m_a.EventA += value; }
            remove { m_a.EventA -= value; }
        }
    }
