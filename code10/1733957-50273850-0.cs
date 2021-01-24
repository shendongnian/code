    // List<CustomClass> foo;
    var listV = Expression.Variable(typeof(List<CustomClass>), "foo");
    // new List<CustomClass>()
    var newL = Expression.New(typeof(List<CustomClass>));
    // foo = new List<CustomClass>()
    var assV = Expression.Assign(listV, newL);
    // new CustomClass()
    var newEl = Expression.New(typeof(CustomClass));
    // foo.Add(new CustomClass())
    var addEl = Expression.Call(listV, "Add", null, newEl);
    var be = Expression.Block(new[] { listV }, assV, addEl);
