    var list = new List<int>(new[] { 1, 2, 3 });
    list.Find(new DivisibleBy2Finder());
    // Somewhere far away
    private class DivisibleBy2Finder : IFinder<int> {
        public bool Matches(int i) {
            return i % 2 == 0;
        }
    }
