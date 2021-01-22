    //calling code
    foreach(int i in obCustomClass.Each())
    {
        Console.WriteLine(i.ToString());
    }
    
    // CustomClass implementation
    private int[] data = {1,2,3,4,5,6,7,8,9,10};
    public IEnumerable<int> Each()
    {
       for(int iLooper=0; iLooper<data.Length; ++iLooper)
            yield return data[iLooper]; 
    }
