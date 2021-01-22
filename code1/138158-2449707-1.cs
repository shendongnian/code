    public string TrimNulls(byte[] data)
    {
        int rOffset = data.Length - 1;
    
        for(int i = data.Length - 1; i >= 0; i--)
        {
            rOffset = i;
    
            if(data[i] != (byte)0) break;            
        }
    
        return System.Text.Encoding.ASCII.GetString(data, 0, rOffset + 1);
    }
