    [Fact]
    public void Test()
    {
        var query = new Query(new int[] { 1, 2, 3 });
        var json = JsonConvert.SerializeObject(query);
        Assert.Equal("[1,2,3]", json);
        var deserialized = JsonConvert.DeserializeObject<Query>(json);
        Assert.Equal(1, deserialized.IDs[0]);
        Assert.Equal(2, deserialized.IDs[1]);
        Assert.Equal(3, deserialized.IDs[2]);
    }
