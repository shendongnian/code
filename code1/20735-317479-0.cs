    public IEnumerable<string> GetValues() {
        foreach(string value in someArray) {
            if (value.StartsWith("A")) { yield return value; }
        }
    }
