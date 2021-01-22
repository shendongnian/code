    [Test]
    [ExpectedException(typeof(Exception))]
    void Test()
    {
        var ie = GetEnum(bad_param);
        var en = ie.GetEnumerator();
        en.MoveNext();
    }
