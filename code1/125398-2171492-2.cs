    private LineItems LineItemsField;
    [DataMember(Order=13, EmitDefaultValue=false)]
    public LineItems LineItems {
        get { return this.LineItemsField; }
        set { this.LineItemsField = value; }
    }
