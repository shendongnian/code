        class Something<TCell>
        {
            internal static TCell Sum(TCell first, TCell second)
            {
                if (typeof(TCell) == typeof(int))
                    return (TCell)((object)(((int)((object)first)) + ((int)((object)second))));
    
                if (typeof(TCell) == typeof(double))
                    return (TCell)((object)(((double)((object)first)) + ((double)((object)second))));
    
                return second;
            }
        }
