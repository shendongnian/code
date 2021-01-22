    [DataMember(Name="AddressType")]
    private string _addressType { get; set; }
    
    public AddressType AddressType
    {
        get
        {
            AddressType result;
            Enum.TryParse(_addressType, out result);
            return result;
        }
    }
