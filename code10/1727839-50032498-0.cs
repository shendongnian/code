    var allDictionary = dictionaryOne.Select(kv => new { kv.Key.Property1, kv.Key.Property2, kv.Value })
                                     .Concat(dictionaryTwo.Select(kv => new { kv.Key.Property1, kv.Key.Property2, kv.Value }))
                                     .Concat(dictionaryThree.Select(kv => new { kv.Key.Property1, kv.Key.Property2, kv.Value }))
                                     .GroupBy(k2v => new { k2v.Property1, k2v.Property2 })
                                     .ToDictionary(k2vg => new { k2vg.Key.Property1, k2vg.Key.Property2 }, k2vg => k2vg.Sum(k2v => k2v.Value));
