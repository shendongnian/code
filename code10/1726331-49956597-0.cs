    public struct GameObjectParams3 // 3 only for example, you need more
    {
        private int NextGet;
        public GameObject Object0;
        public GameObject Object1;
        public GameObject Object2;
        public GameObjectParams3(GameObject g0) : this(g0, null, null) { }
        public GameObjectParams3(GameObject g0, GameObject g1) : this(g0, g1, null) { }
        public GameObjectParams3(GameObject g0, GameObject g1, GameObject g2)
        {
            this.NextGet = 0;
            this.Object0 = g0;
            this.Object1 = g1;
            this.Object2 = g2;
        }
        public GameObject Next()
        {
            GameObject ret;
            switch (this.NextGet)
            {
                case 0: ret = Object0; break;
                case 1: ret = Object1; break;
                case 2: ret = Object2; break;
                default: return null;
            }
            this.NextGet++;
            return ret;
        }
        /*
        public int Length { get { return this.NextPush; } }
        private int NextPush;
        public void Push(GameObject go)
        {
            switch (this.NextPush)
            {
                case 0: Object0 = go; break;
                case 1: Object1 = go; break;
                case 2: Object2 = go; break;
                default: throw new IndexOutOfRangeException();
            }
            this.NextPush++;
        }
        */
    }
