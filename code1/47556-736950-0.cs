    public static ArrayList DuplicateIntArrays(ArrayList input, int copies)
    {
        ArrayList ret = new ArrayList();
        foreach (object element in input)
        {
            if (element is int[])
            {
                for (int i=0; i < copies; i++)
                {
                    ret.Add(element);
                }
            }            
            else
            {
                ret.Add(element);
            }
        }
        return ret;
    }
