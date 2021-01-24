    public static List<string> GetAllElements() {
        List<string> _elements = new List<string>();
        ResetReader();
        while (_reader.Read()) {
            for (int i = 0; i < ColumnsCount; i++)
                _elements.Add(_reader[i].ToString());
        }
        return _elements;
    }
