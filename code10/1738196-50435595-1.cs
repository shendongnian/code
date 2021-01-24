    var resValues = sites
        .Where(s => s != null)
        .SelectMany(s => s
            .Split(',')
            .Skip(2)
            .Take(1) 
            .Select(a => a.Replace("test=", ""))
            .SelectMany(a => a
                .Split('_')
                .Skip(1)
                .Take(1)
                .Select(b => new
                {
                    TestCodeName = GetTestCodeName(a),
                    TestCode = GetTestCode(a, b)
                })))
            .ToDictionary(p => p.TestCodeName, p => p.TestCode);
