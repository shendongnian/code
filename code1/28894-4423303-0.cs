    private int[] RemoveIndices(int[] IndicesArray, int RemoveAt)
{
    int[] newIndicesArray = new int[IndicesArray.Length - 1];
            
    int i = 0;
    int j = 0;
    while (i < IndicesArray.Length)
    {
        if (i != RemoveAt)
        {
            newIndicesArray[j] = IndicesArray[i];
            j++;
        }
        i++;
    }
    return newIndicesArray;
