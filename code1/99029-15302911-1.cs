    // No exception thrown - test fails.
    Assert.IsTrue(
        AssertThrows<InvalidOperationException>(
            () => {}));
    
    // Wrong exception thrown - test fails.
    Assert.IsTrue(
        AssertThrows<InvalidOperationException>(
            () => { throw new ApplicationException(); }));
    
    // Correct exception thrown - test passes.
    Assert.IsTrue(
        AssertThrows<InvalidOperationException>(
            () => { throw new InvalidOperationException(); }));
    
    // Correct exception thrown, but wrong message - test fails.
    Assert.IsTrue(
        AssertThrows<InvalidOperationException>(
            () => { throw new InvalidOperationException("ABCD"); },
            ex => ex.Message == "1234"));
    
    // Correct exception thrown, with correct message - test passes.
    Assert.IsTrue(
        AssertThrows<InvalidOperationException>(
            () => { throw new InvalidOperationException("1234"); },
            ex => ex.Message == "1234"));
