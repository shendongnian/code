    public int Order
    {
        get { return m_order; }
        set
        {
            // Put some rules checking here. Maybe a call to make sure that the order isn't duplicated or some other error based on your business rules.
            m_order = value;
        }
    }
