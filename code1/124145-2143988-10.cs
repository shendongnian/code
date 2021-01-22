    List<Test> tests = new List<Test>() {
                new Test { Name = "aaa", Value = 111, Valid = Valid.Yes },
                new Test { Name = "aaa", Value = 111, Valid = Valid.Yes },
                new Test { Name = "bbb", Value = 112, Valid = Valid.No },
                new Test { Name = "bbb", Value = 111, Valid = Valid.No },
                new Test { Name = "bbb", Value = 220, Valid = Valid.No },
                new Test { Name = "ccc", Value = 220, Valid = Valid.Yes }
    };
    IEnumerable<Test> lookup = GetByIndex(tests, x => x.Name, "bbb");
