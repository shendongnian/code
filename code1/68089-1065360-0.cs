    class B
    {
        private A m_a = new A();
        
        public event EventType EventB
        {
            add { a.EventA += value; }
            remove { a.EventA -= value; }
        }
    }
