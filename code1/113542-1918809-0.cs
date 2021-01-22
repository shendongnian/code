    var things = new[] {
        new Thing { Foo = 1, Bar = 2, Baz = "ONETWO!" },
        new Thing { Foo = 1, Bar = 3, Baz = "ONETHREE!" },
        new Thing { Foo = 1, Bar = 2, Baz = "ONETWO!" }
    }.ToList();
    var bazGroups = things
        .GroupBy(t => t.Foo)
        .ToDictionary(gFoo => gFoo.Key, gFoo => gFoo
            .GroupBy(t => t.Bar)
            .ToDictionary(gBar => gBar.Key, gBar => gBar.First().Baz));
    Debug.Fail("Inspect the bazGroups variable.");
