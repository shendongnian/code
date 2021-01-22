    private DateTime m_internalDateTime;
    public object DateTimeProperty
    {
       get { return m_internalDateTime.ToString(); } // Return a string
       set { m_internalDateTime = (DateTime)value; } // here value is of type DateTime
    }
