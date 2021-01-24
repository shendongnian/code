    public static MatrixData GetLargestBlob(this MatrixData input, ref Tuple<int, int> blobMid)
    {
        MatrixData output = new MatrixData(input.NumberOfRows,input.NumberOfColumns);            
        List<Tuple<int,int>> checkedPixels = new List<Tuple<int, int>>();
        List<Tuple<int,int>> blobs = new List<Tuple<int, int>>();
        List<Tuple<int,int>> largestBlob = new List<Tuple<int, int>>();            
        Random rand = new Random();
        for (int r = 0; r < input.NumberOfRows; r++)
        {
            for(int c = 0; c < input.NumberOfColumns; c++) 
            {
                //skip black pixels
                if (input[r,c]==0) continue;
                int replace = rand.Next(256,int.MaxValue);
                
                if (checkedPixels.Count==0)
                {
                    List<Tuple<int,int>> blob = new List<Tuple<int, int>>();
                    blobs.Add(new Tuple<int, int>(Fill(input,r,c,replace,ref checkedPixels,ref blob), replace)); 
                    if(blob.Count > largestBlob.Count) largestBlob = blob;
                } 
                else
                {
                    if(!checkedPixels.Contains(new Tuple<int, int>(r, c)))
                    {
                        List<Tuple<int,int>> blob = new List<Tuple<int, int>>();
                        blobs.Add(new Tuple<int, int>(Fill(input,r,c,replace,ref checkedPixels,ref blob), replace));
                        if(blob.Count > largestBlob.Count) largestBlob = blob;
                    }
                }                    
            }
        }
        
        //set the output to only show the largest blob
        Tuple<int,int> largest = blobs.Where(r => r.Item1 == (blobs.Max(m => m.Item1))).First();
        for (int r = 0; r < input.NumberOfRows; r++)
        {
            for(int c = 0; c < input.NumberOfColumns; c++) 
            {
                output[r,c] = (input[r,c]==largest.Item2)? 255 : 0;
            }
        }
        //calculate the center of the largest blob
        int xMin = largestBlob.Min(m => m.Item1);
        int xMax = largestBlob.Max(m => m.Item1);
        int yMin = largestBlob.Min(m => m.Item2);
        int yMax = largestBlob.Max(m => m.Item2);            
        int centerX = ((xMax - xMin) / 2) + xMin;
        int centerY = ((yMax - yMin) / 2) + yMin;
        blobMid = new Tuple<int, int>(centerX, centerY);
        
        return output;
    }
    public static int Fill(MatrixData array, int x, int y, int newInt, ref List<Tuple<int,int>> checkedPixels,ref List<Tuple<int,int>> blobPixels)
    {
        int initial = array[x,y];
        int counter = 0;
        Queue<Tuple<int,int>> queue = new Queue<Tuple<int,int>>();
        queue.Enqueue(new Tuple<int, int>(x, y));
        while (queue.Any())
        {
            Tuple<int, int> point = queue.Dequeue();
            if (array[point.Item1, point.Item2] != initial)
                continue;
            array[point.Item1, point.Item2] = newInt;
            checkedPixels.Add(point);
            blobPixels.Add(point);
            counter++;
            EnqueueIfMatches(array, queue, point.Item1 - 1, point.Item2, initial);
            EnqueueIfMatches(array, queue, point.Item1 + 1, point.Item2, initial);
            EnqueueIfMatches(array, queue, point.Item1, point.Item2 - 1, initial);
            EnqueueIfMatches(array, queue, point.Item1, point.Item2 + 1, initial);        
        }
        return counter;
    }
    private static void EnqueueIfMatches(MatrixData array, Queue<Tuple<int, int>> queue, int x, int y, int initial)
    {
        if (x < 0 || x >= array.Data.GetLength(0) || y < 0 || y >= array.Data.GetLength(1))
            return;
        if (array[x, y] == initial)
        queue.Enqueue(new Tuple<int, int>(x, y));
    }
