    if (obj is int i)
    {
        // use i
    }
    else
    {
        string s = obj.ToString();
        if (int.TryParse(s, out int val))
        {
            // use val
        }
        else
        {
            // your exception case
        }
    }
