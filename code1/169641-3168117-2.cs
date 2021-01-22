    if (o is IConvertible)
    {
        d = ((IConvertible)o).ToDouble(null);
    }
    else
    {
        d = 0d;
    }
