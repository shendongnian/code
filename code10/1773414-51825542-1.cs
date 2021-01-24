      List<string> initialList = Enumerable
        .Range(1, 15)
        .Select(i => $"test{i}")
        .ToList();
      int _minMentions = 2;
      int _maxMentions = 3;
      // Random(1): to make outcome reproducible
      // In real life should be new Random();  
      Random _random = new Random(1); 
      int group = 0;
      int groupLength = 0;
      var result = initialList
        .Select((item) => {
          if (--groupLength <= 0) {
            group += 1;
            groupLength = _random.Next(_minMentions, _maxMentions + 1);
          }
          return new { item, group };
        })
        .GroupBy(item => item.group)
        .Select(chunk => chunk
           .Select(item => item.item)
           .ToList())
        .ToList();
      string test = string.Join(Environment.NewLine, result
        .Select(items => string.Join(", ", items))); 
      Console.Write(test);
