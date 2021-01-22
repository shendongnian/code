    string m_ID;
    public string ID
    {
       get { return m_ID; }
       set 
       { 
         //validate value conforms to a certain pattern via a regex match
         m_ID = value;
       }
    }
