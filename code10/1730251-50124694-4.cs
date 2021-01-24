    var testList = new List<TestDto>
    {
        new TestDto { Name = "Test0", TestId = 0 },
        new TestDto { Name = "Test1", TestId = 1 },
        new TestDto { Name = "Test2", TestId = 2 },
        new TestDto { Name = "Test3", TestId = 3 },
        new TestDto { Name = "Test4", TestId = 4 },
    };
    var selectList = testList.ToSelectList(nameof(TestDto.TestId), nameof(TestDto.Name));
