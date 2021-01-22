    public IList<Rule> Rules
    {
      get { return rules.AsReadOnly(); }
    // set { rules = value; -- should not be allowed to set if read only!
    }
