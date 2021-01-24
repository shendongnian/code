    // Get works as expected but set does literally nothing to change the backing field
    private string amount = null;
    public string Amount
    {
        get => amount;
        set 
        {
             // Do literally nothing
        }
    }
