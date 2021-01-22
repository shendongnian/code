    int value = 0;
    int bitDegree = 1; //or short or long, depending on the number of bits
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        if (!string.IsNullOrEmpty(dt.Rows[i]["IsSelected"].ToString())
            && Convert.ToBoolean(dt.Rows[i]["IsSelected"]))
        {
            value += bitDegree;
        }
        bitDegree *= 2;
    }
