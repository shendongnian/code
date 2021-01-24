    private class MemoizedTest
    {
        private int _counter = 0;
        public int Method(int p) => this.Memoized(p, x =>
        {
            return _counter += x;
        });
    }
