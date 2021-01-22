    IEnumerable<string> expected = new List<string> { "a", "b" };
    IEnumerable<string> actual   = new List<string> { "a", "c" }; // mismatching second element
    
    CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    // Helpful failure message!
    //  CollectionAssert.AreEqual failed. (Element at index 1 do not match.)	
    
    Assert.IsTrue(expected.SequenceEqual(actual));
    // Mediocre failure message:
    //  Assert.IsTrue failed. 	
