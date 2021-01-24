    int[] buffer = new int[1000];
    foreach (List<Example> subList in data)
    {
        for (int i = 0; i < subList.Count; i++)
        {
            buffer[i] = subList[i].Id;
        }
        var hash = CalcHashEx(buffer, 0, subList.Count - 1);
        var newHash = checkedUnlock.Add(hash);
        if (newHash)
        {
            //do something
        }
    }
    public static void QuickSort(int[] elements, int left, int right)
    {
        int i = left, j = right;
        int pivot = elements[(left + right) / 2];
        while (i <= j)
        {
            while (elements[i] < pivot)
            {
                i++;
            }
            while (elements[j] > pivot)
            {
                j--;
            }
            if (i <= j)
            {
                // Swap
                int tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;
                i++;
                j--;
            }
        }
        if (left < j)
        {
            QuickSort(elements, left, j);
        }
        if (i < right)
        {
            QuickSort(elements, i, right);
        }
    }
    static int CalcHashEx(int[] value, int startIndex, int endIndex)
    {
        QuickSort(value, startIndex, endIndex);
        int hash;
        unchecked // https://stackoverflow.com/a/263416/40868
        {
            hash = (int)2166136261;
            var i = endIndex + 1;
            while (i-- > 0)
                hash = (hash * 16777619) ^ value[i];
        }
        return hash;
    }
