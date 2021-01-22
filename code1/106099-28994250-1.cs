    [Test]
    public void MultipleInputTypeSample()
    {
        int source;
        SampleEnum result;
        // valid int value
        source = 0;
        result = source.ParseToEnum<SampleEnum>();
        Assert.That(result, Is.EqualTo(SampleEnum.Value1));
        // out of range int value
        source = 15;
        Assert.Throws<ArgumentException>(() => source.ParseToEnum<SampleEnum>());
        // out of range int with default provided
        source = 30;
        result = source.ParseToEnum<SampleEnum>(SampleEnum.Value2);
        Assert.That(result, Is.EqualTo(SampleEnum.Value2));
    }
    private enum SampleEnum
    {
        Value1,
        Value2
    }
