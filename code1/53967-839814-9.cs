    public class Foo
    {
        private readonly SetOnce<int> toBeSetOnce = new SetOnce<int>();
        public int ToBeSetOnce
        {
            get { return toBeSetOnce; }
            set { toBeSetOnce.Value = value; }
        }
    }
