    bool hasRepeatedElements(int[] v)
            {
                if (v.Length > 1)
                {
                    int[] subArray = new int[v.Length - 1];
                    for (int i = 1; i < v.Length; i++)
                    {
                        if (v[0] == v[i])
                            return true;
                        else
                            subArray[i - 1] = v[i];
                    }
                    return hasRepeatedElements(subArray);
                }
    
                return false;
            }
