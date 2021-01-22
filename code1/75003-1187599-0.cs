    public IEnumerable<YourType> SomeMethod(...args...) {
        using(connection+reader) {
            while(reader.Read()) {
                YourType item = BuildObj(reader);
                yield return item;
            }
        }
    }
