    [XmlElement("amount", IsNullable = false)]
    public string SerializableAmount
    {
        get { return this.Amount == null ? "" : this.Amount.ToString(); }
        set { this.Amount = Convert.ToDouble(value); }
    }
