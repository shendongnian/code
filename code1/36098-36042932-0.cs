    public int Split(string value, char separator)
    {
        int resultIndex = 0;
        int startIndex = 0;
    
        // Find the mid-parts
        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] == separator)
            {
                this.buffer[resultIndex] = value.Substring(startIndex, i - startIndex);
                resultIndex++;
                startIndex = i + 1;
            }
        }
    
        // Find the last part
        this.buffer[resultIndex] = value.Substring(startIndex, value.Length - startIndex);
        resultIndex++;
    
        return resultIndex;
