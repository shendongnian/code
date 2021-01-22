    return ReadLines(filename)
        .Select(l =>
                    {
                        string tmp = l.Substring(3, 3);
                        int result;
                        bool success = int.TryParse(tmp, out result);
                        return new
                                   {
                                       Success = success,
                                       Value = result
                                   };
                    })
        .Where(i => i.Success)
        .Select(i => i.Value);
