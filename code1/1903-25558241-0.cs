    private int? hashCode;
    public override int GetHashCode()
    {
        if (!hashCode.HasValue)
        {
            var hash = 0;
            for (var i = 0; i < bytes.Length; i++)
            {
                hash = (hash << 4) + bytes[i];
            }
            hashCode = hash;
        }
        return hashCode.Value;
    }
