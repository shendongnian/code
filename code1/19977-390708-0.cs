    public bool IsMatch(int item) {
        return (item % 3 == 1); // put whatever condition you want here
    }
    public void RemoveMatching() {
        List<int> x = new List<int>();
        x.RemoveAll(new Predicate<int>(IsMatch));
    }
