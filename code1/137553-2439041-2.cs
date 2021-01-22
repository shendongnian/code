    public class BucketBuilder : IStillNeedsMixing, ICanAddColours
    {
        private int _red = 0;
        private int _green = 0;
        private int _blue = 0;
        public IStillNeedsMixing Red(int red)
        {
             _red += red;
             return this;
        }
        public IStillNeedsMixing Green(int green)
        {
             _green += green;
             return this;
        }
        public IStillNeedsMixing Blue(int blue)
        {
             _blue += blue;
             return this;
        }
        public Bucket Mix()
        {
            Bucket bucket = new Bucket(new Paint(_red, _green, _blue));
            bucket.Mix();
            return bucket;
        }
    }
