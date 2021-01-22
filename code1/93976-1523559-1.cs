    public int Order
    {
        get { return m_order; }
        protected set
        {
            // Again, you can do some checking here if you want...
            m_order = value;
            // You can also do other updates if necessary. Perhaps a database update...
        }
    }
