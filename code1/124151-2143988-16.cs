    List<Test> tests = new List<Test>() {
                new Test { Name = "aaa", Value = 111, Valid = Valid.Yes },
                new Test { Name = "aaa", Value = 111, Valid = Valid.Yes },
                new Test { Name = "bbb", Value = 112, Valid = Valid.No },
                new Test { Name = "bbb", Value = 111, Valid = Valid.No },
                new Test { Name = "bbb", Value = 220, Valid = Valid.No },
                new Test { Name = "ccc", Value = 220, Valid = Valid.Yes }
    };
    // build an IndexedList<Text> indexed by Name and Value
    IndexedList<Test> indexed = new IndexedList<Test>(new List<string>() { "Name", "Value" }, tests);
    // lookup where Name == "bbb"
    foreach (var result in indexed.GetByIndex("Name", "bbb")) {
        Console.WriteLine(result.Value);
    }
