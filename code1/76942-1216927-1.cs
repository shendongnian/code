    private string[] myData;
    public IntIndexer(int size)
    {
        myData = new string[size];
        for (int i = 0; i < size; i++)
        {
            myData[i] = "empty";
        }
    }
