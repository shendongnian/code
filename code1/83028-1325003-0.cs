    var newDic = dic
       .SelectMany(pair => pair.Value
                               .Select(val => new { Key = val, Value = pair.Key }))
       .GroupBy(item => item.Key)
       .ToDictionary(gr => gr.Key, gr => gr.Select(item => item.Value));
