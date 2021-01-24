    public float GetSize(Size size)
    {
        switch (size)
        {
            case Size.Eight :
                return 8;
            case Size.EightPointFive :
                return 8.5;
            // rest of the sizes.
            default: return -1;
        }
    
        //unhandled
        return -1;
    }
