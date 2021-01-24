    var results = new List<string>();
    
    try { results.Add(await t1); } catch { results.Add("Exception"); };
    try { results.Add(await t2); } catch { results.Add("Exception"); };
    try { results.Add(await t3); } catch { results.Add("Exception"); };
    
    return string.Join("|", results);
