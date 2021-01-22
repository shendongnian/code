    foreach (var prop in typeof(TModelType).GetProperties())
    {
        var expectedValue = prop.GetValue(expected, null);
        var actualValue = prop.GetValue(actual, null);
        var expectedEnumerable = (expectedValue as IEnumerable);
        var actualEnumerable = (actualValue as IEnumerable);
    
        if (expectedEnumerable != null)
        {
            Assert.IsTrue(expectedEnumerable.SequenceEqual(actualEnumerable))
            continue;
        }
    
        Assert.AreEqual(expectedValue, actualValue);
    }
