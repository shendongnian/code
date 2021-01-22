         var lr =
        (from gr in
            (from pair in D1.Union(D2).Union(D3)
             group pair by pair.Key)
         select new KeyValuePair<int, IEnumerable<List<string>>>(gr.Key, gr.Select(x => x.Value))
        ).ToDictionary(k => k.Key, v => v.Value.Aggregate((t, s) => (new List<string>(t.Union(s)))));
