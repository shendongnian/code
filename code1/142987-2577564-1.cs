    [DataMember()]
    public IList<Person> Feedback {
    	get { return m_Feedback; }
    	set {
    		if ((value != null)) {
    			m_Feedback = new List<Person>(value);
    
    		} else {
    			m_Feedback = new List<Person>();
    		}
    	}
    }
