    class Person: IPerson
    {
        INationality Nationality
        {
            get { return m_nationality; }
            set 
            {
              if (m_nationality <> value)
              {
                 m_nationality = value;
                 this.IsDirty = true;
              }
            }
        }
    }
