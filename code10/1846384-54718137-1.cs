    sealed class Change
    {
        public long Two { get; }
        public long Five { get; }
        public long Ten { get; }
        public Change(long two, long five, long ten)
        {
          this.Two = two;
          this.Five = five;
          this.Ten = ten;
        }
        public Change AddTwo() => new Change(Two + 1, Five, Ten);
        public Change AddFive() => new Change(Two, Five + 1, Ten);
        public Change AddTen() => new Change(Two, Five, Ten + 1);
        public long Count => Two + Five + Ten;
        public long Total => Two * 2 + Five * 5 + Ten * 10;
    }
