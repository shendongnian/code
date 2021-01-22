    void Test_IDictionary_Add(IDictionary a, IDictionary b)
    {
        string key = "Key1", badKey = 87;
        int value = 9, badValue = "Horse";
        a.Add(key, value);
        b.Add(key, value);
        Assert.That(a.Count, Is.EqualTo(b.Count));
        Assert.That(a.Contains(key), Is.EqualTo(b.Contains(key)));
        Assert.That(a.ContainsKey(key), Is.EqualTo(b.ContainsKey(key)));
        Assert.That(a.ContainsValue(value), Is.EqualTo(b.ContainsValue(value)));
        Assert.That(a.Contains(badKey), Is.EqualTo(b.Contains(badKey)));
        Assert.That(a.ContainsValue(badValue), Is.EqualTo(b.ContainsValue(badValue)));
        // ... and so on and so forth
    }
    [Test]
    void MyDictionary_Add()
    {
        Test_IDictionary_Add(new MyDictionary(), new Hashtable());
    }
