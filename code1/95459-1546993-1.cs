    // Expected result.
    List<string> expected = new List<string>();
    expected.Add( "a" );
    expected.Add( "b" );
    expected.Add( "c" );
    // Actual result
    actual = new List<string>();
    actual.Add( "a" );
    actual.Add( "b" );
    actual.Add( "c" );
    // Verdict
    Assert.IsTrue( ListEquals(actual, expected) );
