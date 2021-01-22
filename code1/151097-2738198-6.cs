    // 1. enumerating over a collection
    foreach (Table table in dbServer.Tables)
    {
        // 2. checking a condition
        if (!table.IsSet)
        {
            // 3. enumerating over another collection
            foreach (Reference refer in table.References)
            {
                // 4. checking a condition
                if (refer.PrimaryTable == "myTable")
                {
                    // 5. adding to a collection
                    tables.Add(table);
                }
            }
        }
    }
