    int[] arr = new int[10] { 45, 3, 64, 6, 24, 75, 3, 6, 24, 45 };
    protected void Page_Load(object sender, EventArgs e)
    {
        secondHighestLowestNumber();
        secoundLowestNumber();
    }
    private void secondHighestLowestNumber()
    {
        
        int firstHighestNumber = arr[0];
        int secondHighestNumber = arr[0];
        for(int i = 0; i<arr.Length; i++)
        {
            if (arr[i]>firstHighestNumber)
            {
                firstHighestNumber = arr[i];
            }
        }
        for (int x = 0; x < arr.Length; x++)
        {
            if (arr[x]>secondHighestNumber && firstHighestNumber!=arr[x])
            {
                secondHighestNumber = arr[x];
            }
        }
        Response.Write("secondHighestNumber---- " + secondHighestNumber + "</br>");
    }
    private void secoundLowestNumber()
    {
        int firstLowestNumber = arr[0];
        int secondLowestNumber = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < firstLowestNumber)
            {
                firstLowestNumber = arr[i];
            }
        }
        for (int x = 0; x < arr.Length; x++)
        {
            if (arr[x] < secondLowestNumber && firstLowestNumber != arr[x])
            {
                secondLowestNumber = arr[x];
            }
        }
        Response.Write("secondLowestNumber---- " + secondLowestNumber + "</br>");
    }
