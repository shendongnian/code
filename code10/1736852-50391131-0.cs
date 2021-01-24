    var result = new List<int> { };
    for (int i = 0; i < candid.Count(); i++)
    {
        for (int j = i + 1; j < candid.Count(); j++)
        {
            var value =
                int.Parse(
                    new string(
                        string.Concat(candid[i], candid[j])
                            .OrderBy(x => x)
                            .Distinct()
                            .ToArray()
                        )
                    );
            if (true)
            {
                result.Add(value);
            }
        }
    }
    return result.Distinct().ToArray();
