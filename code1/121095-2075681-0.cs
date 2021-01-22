    object b = t["key"];
    // note I assume property here:
    object id1 = b.GetType().GetProperty("ID").GetValue(b, null);
    // or for a field:
    object id2 = b.GetType().GetField("ID").GetValue(b);
