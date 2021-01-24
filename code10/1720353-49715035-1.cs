    public static bool Compare(bool compareTypes = false, params object[] values)
    {
        if (!compareTypes)
        {
            if (values is null || values.Length == 0) return false;
            else if (values.Length == 1) return true;
            else if (values.Lenght == 2) return values[0] == values[1];
            else 
            {
                bool result = true;
                for(int i = 0; i < values.Lenght - 1; i++)
                {
                    if(value[i] != value[i+1])
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }
        else
        {
            if (values is null || values.Length == 0) return false;
            else if (values.Length == 1) return true;
            else if (values.Lenght == 2) return values[0].GetType() == values[1].GetType();
            else 
            {
                bool result = true;
                for(int i = 0; i < values.Lenght - 1; i++)
                {
                    if(values[i].GetType() != values[i+1].GetType())
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }
    }
