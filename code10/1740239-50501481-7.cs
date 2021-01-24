    var sqlValues = new List<ISQLValue>
    {
        new SQLValue<string> { nam="PlayerName", typ="string", val="Bot1" }
        new SQLValue<bool> { nam="Ally", typ="bool", val=true }
        new SQLValue<int> { nam="Levl", typ="int", val=2 }
    };
    
    foreach (var value in sqlValues)
    {
        Console.WriteLine($"nam = {value.name}, typ = {value.typ}, val = {value.val}");
    }
