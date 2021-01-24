    class Chain
    {
        readonly List<Unit> _units;
        public IReadOnlyList<Unit> Units => _units;
        public string Key => string.Concat(_units.Select(u => u.State ? "1" : "0"));
        public Chain(params bool[] units)
        {
            _units = units.Select(u => new Unit { State = u }).ToList();
        }
    }
