    var context1 = new DbContext();
    _fooList = new List<Foo>
    {
        // Thousands of datasets
    }
    context1.Set<Foo>().AddRange(_fooList);
    var context2 = new DbContext();
    _barList = new List<Bar>
    {
        // Thousands of datasets
    }
    context2.Set<Bar>().AddRange(_barList);
    var fooTask = context1.SaveChangesAsync();
    var barTask = context2.SaveChangesAsync();
    await Task.WhenAll(new Task[] {fooTask, barTask});
