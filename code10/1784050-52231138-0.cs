    [TestMethod]
    public void MoqOutParameter()
    {
        // Arrange
        Mock<ISample> mockSample = new Mock<ISample>();
        SampleKey MyKey = new SampleKey() { prop1 = 1 };
        SampleOutput sampleOut = new SampleOutput() { prop2 = 2 };
        SampleOutput nullOut = null;
        mockSample.Setup(s => s.SampleMethod(It.IsAny<SampleKey>(),
            out nullOut)).Returns(false);
        mockSample.Setup(s => s.SampleMethod(It.Is<SampleKey>(t => t.Equals(MyKey)),
            out sampleOut)).Returns(true);
        // Act  
        SampleOutput out1;
        var result1 = mockSample.Object.SampleMethod(MyKey, out out1);
        SampleOutput out2;
        var result2 = mockSample.Object.SampleMethod(new SampleKey(), out out2);
            
        // Assert
        Assert.True(result1);
        Assert.AreEqual(out1, sampleOut);
        Assert.False(result2);
        Assert.Null(out2);
    }
