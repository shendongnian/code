    static List<bool> AsArray(string boolString)
    {
        List<bool> toArray = new List<bool>();
        foreach (char boolChar in boolString)
        {
            if (boolChar == '0')
            {
                toArray.Add(false);
            }
            else if (boolChar == '1')
            {
                toArray.Add(true);
            }
            else
            {
                throw new Exception("String can only be made of 1 and 0.");
            }
        }
        return toArray;
    }
