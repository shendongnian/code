    private System.DateTime? someDateField;
    public string someDate
    {
        get
        {
            return someDateField?.ToString("MM-dd-yyyy");
        }
        set
        {
            dobField = System.DateTime.Parse(value);
        }
    }
