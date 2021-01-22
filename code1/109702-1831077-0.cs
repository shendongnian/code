    public byte[] Process(IEnumerable input) {
        foreach (var elem in input) {
            foreach (PropertyInfo prop in elem.GetType().GetProperties()) {
                Object value = prop.GetValue(elem, null);
                // add value to byte[]
            }
        }
        return bytes;
    }
