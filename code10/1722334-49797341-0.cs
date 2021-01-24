    public string GroupOperator
    {
        get
        {
            return ConvertOperatorToString();
        }
    }
    private bool isOrOperator = false;
    public bool IsOrOperator
    {
        get
        {
            return this.isOrOperator;
        }
        set
        {
            this.isOrOperator = value;
            OnPropertyChanged("IsOrOperator");
            OnPropertyChanged("GroupOperator");
        }
    }
