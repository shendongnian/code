    int? GetJustIntPart(string original)
    {
        var split = original.Split('_');
        int test;
        foreach (var item in split)
        {
            if (int.TryParse(item, out test))
                return test;
        }
        return null;
    }
