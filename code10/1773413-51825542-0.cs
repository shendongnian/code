      int group = 0;
      int groupLength = 0;
      var result = initialList
        .Select((item) => {
          if (--groupLength <= 0) {
            group += 1;
            groupLength = _random.Next(2, 4);
          }
          return new { item, group };
        })
        .GroupBy(item => item.group)
        .Select(chunk => chunk
           .Select(item => item.item)
           .ToList())
        .ToList();
