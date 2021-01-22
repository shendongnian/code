    public class BucketBuilder
    {
        private int _red = 0;
        private int _green = 0;
        private int _blue = 0;
        public Bucket Mix()
        {
            Bucket bucket = new Bucket(_paint);
            bucket.Mix();
            return bucket;
        }
    }
