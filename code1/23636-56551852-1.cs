    public decimal ConvertToDecimal(AbideDecimal value)
    {
        return new decimal(new int[] { value.V1, value.V2, value.V3, value.V4 });
    }
    public ProtoDecimal ConvertFromDecimal(decimal value)
    {
        var bits = decimal.GetBits(value);
        return new ProtoDecimal 
        {
            V1 = bits[0],
            V2 = bits[1],
            V3 = bits[2],
            V4 = bits[3]
        }
    }
            
