    public IActionResult Foo(int day, int month, int year)
    {
        var givenDate = new DateTime(year, month, day);
        ...
    }
