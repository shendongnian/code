    public static int SubListIndex<T>(this IList<T> list, int start, IList<T> sublist)
    {
        for (int listIndex = start; listIndex < list.Count - sublist.Count + 1; listIndex++)
        {
            int count = 0;
            while (count < sublist.Count && sublist[count].Equals(list[listIndex + count]))
                count++;
            if (count == sublist.Count)
                return listIndex;
        }
        return -1;
    }
