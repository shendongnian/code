    public static int FindLetter(IList<string>[] arr, string search)
    {
        for(int i = 0; i < arr.Length; ++i)
        {
            if(arr[i].Contains(search)) 
            {
                return i;
            }
        }
        return -1;
    }
