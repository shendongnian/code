        List<int> concat = new List<int>();
        using (int[] a = Enumerable.Range(0, 1000 * 1024 * 1024 / 4).ToArray()){
            concat.AddRange(a.Skip(500 * 1024 * 1024 / 4));
        }
        using (int[] b = Enumerable.Range(0, 1000 * 1024 * 1024 / 4).ToArray()){
            concat.AddRange(b.Skip(500 * 1024 * 1024 / 4));
        }
        // Do a GC.Collect() if you really don't want to put this in it's own scope for some reason.
