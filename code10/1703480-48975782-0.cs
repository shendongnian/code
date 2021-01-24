    IEnumerable<List<int>> F() {
        return File.ReadLines("input.txt")
            .Select(a => a.Split(' ').Skip(1).Select(int.Parse).ToList())
            .Where(a => a.Count >= 2)
            .Take(3).OrderBy(a => a.Sum())
            .Select(a => { Console.Write(a[0]); return a; })
            .ToList();
    }
