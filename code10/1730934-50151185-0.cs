    [DataContract]
    public struct ProductId : IEquatable<ProductId>
    {
    [DataMember]
    readonly string productId;
    public ProductId(string productId)
    {
        this.productId = productId
    }
    public override string ToString() => productId ?? string.Empty;
    }
