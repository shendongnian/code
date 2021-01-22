    public FuelConstants<T>()
    {
        if (typeof(T) == typeof(int))
        {
            C_percentage = 5;
            H_percentage = 4;
            O_percentage = 3;
            N_percentage = 2;
            S_percentage = 1;
        }
        else if (typeof(T) == typeof(double))
        {
            C_percentage = 5.0;
            H_percentage = 4.0;
            O_percentage = 3.0;
            N_percentage = 2.0;
            S_percentage = 1.0;
        }
        // etc.
    }
