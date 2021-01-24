    var items = new List<object> {
                       new { id = 1, parentId = 0, children = new List<object>() },
                       new { id = 2, parentId = 3, children = new List<object>() },
                       new { id = 3, parentId = 1, children = new List<object>() },
                       new { id = 4, parentId = 0, children = new List<object>() }
    };
    dynamic dy = items[0];
    Console.WriteLine(dy.id);
