     int[,] numbers = new int[3, 2] { {1, 2}, {3, 4}, {8, 6} };
               List<int[]> arrays = new List<int[]>();
               for (int i = 0; i < 3; i++)
               {
                   int[] arr = new int[2];
                   for (int k = 0; k < 2; k++)
                   {
                       arr[k] = numbers[i, k];
                   }
    
                   arrays.Add(arr);
               }
    
               int[] newArray = arrays[1]; //will give int[] { 3, 4}
