    static IEnumerable<SomeType> ReadFrom(string file) {
        string line;
        using(var file = File.OpenText(file)) {
            while((line = file.ReadLine()) != null) {
                SomeType newRecord = /* parse line */
                yield return newRecord;
            }
        }
    }
