    [NotMapped]
    public string ResidentialName { get { return this.ResidentialId > 0 && this.Residential != null ? this.Residential.Name : String.Empty; } set { } }
    [NotMapped]
    public int UserDocumentCount { get { return this.UserDocument != null ? this.UserDocument.Count : 0; } set { } }
    [NotMapped]
    public int UserPaymentCount { get { return this.UserPayment != null ? this.UserPayment.Count : 0; } set { } }
