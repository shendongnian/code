    public StringBuilder Append(string value)
    {
    if (value != null)
    {
        char[] array = this.m_ChunkChars;
        int i = this.m_ChunkLength;
        int length = value.Length;
        int j = i + length;
        if (j >= array.Length)
        {
            this.AppendHelper(value);
            goto IL_82;
        }
        if (length > 2)
        {
               /* CUT CODE TO FIT */
        }
        else
        {
            if (length > 0)
            {
                array[i] = value[0];
            }
            if (length <= 1)
            {
                goto IL_72;
            }
            array[i + 1] = value[1];
        }
        IL_72:
        this.m_ChunkLength = j;
    }
    IL_82:
    return this;
   }
