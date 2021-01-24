        private readonly System.Random _random = new System.Random((int) (DateTime.UtcNow.Ticks & 0x7fff_ffff));
        private readonly HashSet<int> _previousNumbers = new HashSet<int>();
        private const int Min = 0;
        private const int Max = 9999;
        public int GetNextRandom()
        {
            int next;
            do
            {
                next = _random.Next(Min, Max);
            } while (_previousNumbers.Contains(next) && _previousNumbers.Count < Max-Min);
            _previousNumbers.Add(next);
            return next;
        }
