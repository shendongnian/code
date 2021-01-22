    if (value != null)
    {
        TEnum result;
        if (Enum.TryParse(value.ToString(), true, out result))
        {
            // since an out-of-range int can be cast to TEnum, double-check that result is valid
            if (Enum.IsDefined(typeof(TEnum), result.ToString()))
            {
                return result;
            }
        }
    }
