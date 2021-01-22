    using Angara.Data;
    using System.Collections.Immutable;
    ...
    var table = Table.Load("data.csv");
    // Print schema:
    foreach(Column c in table)
    {
        string colType;
        if (c.Rows.IsRealColumn) colType = "double";
        else if (c.Rows.IsStringColumn) colType = "string";
        else if (c.Rows.IsDateColumn) colType = "date";
        else if (c.Rows.IsIntColumn) colType = "int";
        else colType = "bool";
        Console.WriteLine("{0} of type {1}", c.Name, colType);
    }
    // Get column data:
    ImmutableArray<double> a = table["a"].Rows.AsReal;
    ImmutableArray<string> b = table["b"].Rows.AsString;
    Table.Save(table, "data2.csv");
