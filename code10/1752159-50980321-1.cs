    while ((line = reader.ReadLine()) != null)
    {
        if (line.StartsWith("!"))
        {
            table = CreateDataTable(reader, line);
        }
        else
        {
            AddToTable(table); // Error: "Unassigned local variable"
        }
    }
