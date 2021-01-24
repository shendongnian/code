     private static void Scatter(int[] array, List<List<int>> buckets)
     {
         foreach (int value in array)
         {
             int bucketNumber = GetBucketNumber(value);
             buckets[bucketNumber].Add(value); // ERROR HERE
         }
     }
