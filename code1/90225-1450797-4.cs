    IEnumerable<string> Split(string str, int chunkSize)
    {
        var totalPieces = str.Length / chunkSize + (str.Length % chunkSize > 0 ? 1 : 0);
        return Enumerable.Range(0, totalPieces)
            .Select(i => {
                if (i == totalPieces - 1)
                    return str.Substring(i * chunkSize);
                else
                    return str.Substring(i * chunkSize, chunkSize);
            });
    }
