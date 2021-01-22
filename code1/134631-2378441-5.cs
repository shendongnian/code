    // Base class field declaration and constructor
    protected string prefix;
    public Transaction()
    {
      prefix = "Primary";
    }
    // Child class constructor
    public SecondaryTransaction()
    {
      prefix = "Secondary";
    }
