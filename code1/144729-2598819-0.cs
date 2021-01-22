    bool isReadOnly;
    public ClassC(bool isReadOnly)
    {
        this.isReadOnly = isReadOnly;
    }
    
    int _issueNumber;
    public int IssueNumber
    {
        get
        {
            return _issueNumber;
        }
        set
        {
            if(!isReadOnly)
            {
                _issueNumber = value;
            }
        }
    }
