    var items = from key in first.Keys.Concat(second.Keys).Distinct()
                let firstList = first.GetValueOrDefault(key) ?? new List<string>()
                let secondList = second.GetValueOrDefault(key) ?? new List<string>()
                select new { Key = key,
                             Additional = secondList.Except(firstList),
                             Missing = firstList.Except(secondList) };
    var result = items.ToDictionary(x => x.Key,
                                    x => new MyClass(x.Additional, x.Missing));
