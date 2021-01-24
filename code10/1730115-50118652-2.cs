    public int MaximumLength
    {
        get
        {
            int maximumLength = 0;
            for (Node i = Head; i != null; i = i.Next)
            {
                if (i.Text.Length > maximumLength)
                {
                    maximumLength  = i.Text.Length;
                }
            }
    
            return maximumLength;
        }
    }
