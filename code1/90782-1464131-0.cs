    private bool EqualsTo(Binary binary)
    {
    if (this != binary)
    {
        if (binary == null)
        {
            return false;
        }
        if (this.bytes.Length != binary.bytes.Length)
        {
            return false;
        }
        if (this.hashCode != binary.hashCode)
        {
            return false;
        }
        int index = 0;
        int length = this.bytes.Length;
        while (index < length)
        {
            if (this.bytes[index] != binary.bytes[index])
            {
                return false;
            }
            index++;
        }
    }
    return true;
}
 
 
