    static void Main(string[] args)
    {
        int[] array = new int[8 * 8 * 4];
        // Use mm=3
        Packed3dArray pa = new Packed3dArray(array, 3);
        int width = pa.Width    // width = 8
        int height = pa.Height  // height = 8
        int hig = pa.Hig        // hig = 4    
        // Set the last element to one using the default indexer (see code).
        pa[7, 7, 3] = 1;
    
        // Go through all the elements and unpack the (x,y,z) values into an index:
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                for (int wid = 0; wid < 4; wid++)
                {
                    Debug.WriteLine($"[{row},{col},{wid}]=[{pa.Index(row, col, wid)}]={pa[row,col,wid]}");
                }
            }
        }
    
        // Recover the original array by using Enumerable.ToArray() extension
        int[] copy = pa.ToArray();
    }
