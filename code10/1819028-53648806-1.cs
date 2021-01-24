    public bool CustomEquals(object o1, object o2) {
        if (o1 is int && o2 is string) {
            return o1 == int.Parse((string)o2);
        }
        // handle other special cases here...
        return o1 == o2;
    }
    // usage:
    FilteredList.AddRange(BaseList.FindAll(x => CustomEquals(propertyValue, word)));
