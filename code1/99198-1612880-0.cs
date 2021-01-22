    class Foo
    {
        private List<float> _data = new List<float>();
        public float Total {get; private set;}
        public void Add(float f) { _data.Add(f); Total += f; }
    }
