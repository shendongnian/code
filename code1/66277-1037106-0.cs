        bool valuesAreNotTheSame = true;
        if (IgC)
        {
            if (val1.ToUpper() == val2.ToUpper())
            {
                valuesAreNotTheSame = false;
            }
        }
        else
        {
            if (val1 == val2)
            {
                valuesAreNotTheSame = false;
            }
        }
        return valuesAreNotTheSame;
