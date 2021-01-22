    class Example
    {
        private BindingList&lt;string&gt; m_names = new BindingList&lt;string&gt;();
        public IEnumerable&lt;string&gt; Names { get { return m_names; } }
        public event AddingNewEventHandler NamesAdded
        {
            add { m_names.AddingNew += value; }
            remove { m_names.AddingNew -= value; }
        }
        public void Add(string name)
        {
            m_names.Add(name);
        }
    }
