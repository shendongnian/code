    [TestClass]
    public class WhenGettingDescriptionOfAnEnum
    {
      private enum SampleEnum
      {
        First,
        [Description("description")]
        Second
      }
    
      [TestMethod]
      public void ShouldReturnNameOfEnumIfItHasNoDescription()
      {
        SampleEnum.First.GetDescription().Should().Be("First");
      }
    
      [TestMethod]
      public void ShouldReturnDescriptionIfThereIsOne()
      {
        SampleEnum.Second.GetDescription().Should().Be("description");
      }
    }
