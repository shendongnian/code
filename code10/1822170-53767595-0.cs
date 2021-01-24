    public void OP_Branch(bool condition, sbyte b)
    {
        cv.PC += 2;
    
        if (condition)
        {
            cv.PC += (ushort)b;
        }
    }
