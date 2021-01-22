        public enum BucketizeDirectionEnum
        {
            LowerBoundInclusive,
            UpperBoundInclusive
        }
        public static int[] Bucketize(this IList<double> source, int totalBuckets, BucketizeDirectionEnum inclusivity = BucketizeDirectionEnum.UpperBoundInclusive)
        {
            var min = source.Min();
            var max = source.Max();
            var buckets = new int[totalBuckets];
            var bucketSize = (max - min) / totalBuckets;
            if (inclusivity == BucketizeDirectionEnum.LowerBoundInclusive)
            {
                foreach (var value in source)
                {
                    int bucketIndex = (int)((value - min) / bucketSize);
                    if (bucketIndex == totalBuckets)
                        continue;
                    buckets[bucketIndex]++;
                }
            }
            else
            {
                foreach (var value in source)
                {
                    int bucketIndex = (int)Math.Ceiling((value - min) / bucketSize) - 1;
                    if (bucketIndex < 0)
                        continue;
                    buckets[bucketIndex]++;
                }
            }
      
            return buckets;
        }
