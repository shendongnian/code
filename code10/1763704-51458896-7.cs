    #region Expandable Invoice
    /// <summary>
    /// ID of the invoice this charge is for if one exists.
    /// </summary>
    public string InvoiceId { get; set; }
    [JsonIgnore]
    public StripeInvoice Invoice { get; set; }
    [JsonProperty("invoice")]
    internal object InternalInvoice
    {
        set
        {
            StringOrObject<StripeInvoice>.Map(value, s => this.InvoiceId = s, o => this.Invoice = o);
        }
    }
    #endregion
