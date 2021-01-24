    foreach (Match m in matches)
    {
        var e = new EntityRange();
        e.EntityId = m.Groups[1].Value;
        e.EntityName = m.Groups[2].Value;
        e.Offset = m.Index;            // HERE
        e.Length = m.Index + m.Length; // HERE
        list.Add(e);                   // HERE
    }
