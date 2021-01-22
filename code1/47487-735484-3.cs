    public string GetAsCsv(Func<CheckBox, string> getValue)
    {
        var buffer = new StringBuilder();
        foreach (var cb in SelectedCheckBoxes)
        {
            buffer.Append(getValue(cb)).Append(",");
        }
        return DropLastComma(buffer.ToString());
    }
