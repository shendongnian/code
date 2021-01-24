    float Sqrt(int x)
    {
        if (x > 0)
        {
            // Calculate square root
            return Math.Sqrt(x);
        }
        else
        {
            // Ignore imaginary numbers for now, use absolute value
            throw new System.ArgumentException("x must be greater than 0");
        }
    }
