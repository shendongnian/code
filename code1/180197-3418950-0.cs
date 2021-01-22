        Level1 x = o as Level2;
        if (x != null)
        {
            DoMethod(x); // Resolves to DoMethod(Level1)
        } 
        else
        {
            Level2 y = o as Level2;
            if (y != null)
            {
                DoMethod(y); // Resolves to DoMethod(Level2)
            }
        }
    Again, this is pretty ugly
