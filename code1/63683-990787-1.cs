    protected BDA da;
    public BusinessDataControllerBase()
    {
      // Initialize the respective Data Access Layer passed by the concrete class
      da = new BDA();
    }
