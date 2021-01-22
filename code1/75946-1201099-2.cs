    class One
    {
        int _first = 1;
        int _second = 2;
        public int First { get { return _first; } }
        public int Second { get { return _second; } }
    }
    class Two
    {
        string _third = "Third";
        string _fourth = "Fourth";
        public string Third { get { return _third; } }
        public string Fourth { get { return _fourth; } }
    }
    class Comp
    {
        int _int1 = 100;
        One _part1 = new One();
        Two _part2 = new Two();
        public One Part1 { get { return _part1; } }
        public Two Part2 { get { return _part2; } }
        public int Int1 { get { return _int1; } }
    }
