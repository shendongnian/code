    static IEnumerable<SomeType> ReadFrom(string file) {
        string line;
        using(var reader = File.OpenText(file)) {
            while((line = reader.ReadLine()) != null) {
                SomeType newRecord = /* parse line */
                yield return newRecord;
            }
        }
    }
