    // This implementation works great if you assume the byte[] arrays
    // are themselves cryptographic hashes. It probably works alright too,
    // for general-purpose byte arrays.
    public override int GetHashCode(byte[] obj)
    {
        if (obj == null) {
            throw new ArgumentNullException("obj");
        }
        if (obj.Length >= 4) {
            return BitConverter.ToInt32(obj, 0);
        }
        // Length occupies at most 2 bits. Might as well store them in the high order byte
        int value = obj.Length;
        foreach (var b in obj) {
            value <<= 8;
            value += b;
        }
        return value;
    }
