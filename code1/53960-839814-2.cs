    public class Foo
    {
        private SetOnce<int> toBeSetOnce;
        public int ToBeSetOnce
        {
            get { return toBeSetOnce; }
            set { toBeSetOnce.Value = value; }
        }
    }
