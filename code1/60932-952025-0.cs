      public Dictionary<string,string> StringToDictonary(string KeyValueData, char KeyValueSeparator, char ItemSeparator)
    {
        Dictionary<string, string> Dic = new Dictionary<string, string>();
        string[] cells = KeyValueData.Split(ItemSeparator);
        foreach (string cell in cells)
        {
            if (!string.IsNullOrEmpty(cell))
            {
                string[] value = cell.Split(KeyValueSeparator);
                if (!string.IsNullOrEmpty(value[0]) && !string.IsNullOrEmpty(value[1]))
                {
                    Dic.Add(value[0], value[1]);
                }
            }
        }
        return Dic;
    }
