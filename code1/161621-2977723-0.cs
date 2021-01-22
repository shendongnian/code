    int[][] array = new int[][] 
    {
        new int[] {0, 0, 0, 3, 0, 0, 0, 0},
        new int[] {0, 0, 1, 0, 0, 0, 0},
        new int[] {0, 0, 0, 2, 0, 0, 0, 0 },
        new int[] {0, 0, 0, 0, 0 },
        new int[] {0, 0, 0, 0, 0, 0, 0 }
    };
    var query = (from row in array.Select((r, idx) => new { r, idx })
                 where row.r.Any(item => item != 0)
                 select new
                 {
                     Row = row.idx,
                     Column = (from item in row.r.Select((i, idx) => new { i, idx })
                               where item.i != 0
                               select item.idx).Last()
                 }).Last();
    Console.WriteLine("{0}\t{1}", query.Row, query.Column);
