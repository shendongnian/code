    if (line_to_edit >= arrLine.Length)
    {
        List<string> list(arrLine);
        while (List.Length < line_to_edit) { list.Add(string.Empty); }
        list.Add(newText);
        arrLine = list.ToArray();
    }
    else { … old code from question… }
