    public async Task<Tuple<List<string>, int>> GetTupleResultAsync()
    {
            List<string> listd = new List<string>() { "A", "A", "D", "E" };
            //Test code to await
            await Task.Run(() => "");
            return new Tuple<List<string>, int>(listd, listd.Count);
    }
