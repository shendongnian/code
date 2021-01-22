    string myVariable;
    public string MyVariable
    {
        get
        {
            return myVariable;
        }
        set
        {
            myVariable = value;
            MyVariableHasBeenChanged();
        }
    }
    private void MyVariableHasBeenChanged()
    {
            
    }
