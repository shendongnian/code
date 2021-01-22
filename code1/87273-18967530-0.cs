    var list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }; //Added 0 in front on purpose in order to enhance simplicity.
    int[] array = list.ToArray();
    int step = 4;
    List<int[]> listSegments = new List<int[]>();
    
    for(int i = 0; i < array.Length; i+=step)
    {
         int[] segment = new ArraySegment<int>(array, i, step).ToArray();
         listSegments.Add(segment);
    }
