    public bool PropertyThatRequiredAnotherFieldToBeFilled
    {
      get;
      set;
    }
            
    [Required(ErrorMessage = "*")] 
    public string DepentedProperty
    {
      get;
      set;
    }
                
