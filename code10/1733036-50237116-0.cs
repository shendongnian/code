    public bool IsSymetric(string str)
    {
        if(str == null) return true; // or false or throw an exception
        for(int i = 0; i < str.Length/2; i++)
        {
            if(str[i] != str[str.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
