[Test]
public void MoqUsingSetup()
{
    //arrange
    var index = new Mock<Index>();
    index.SetupSet(o => o["Key"] = "Value").Verifiable();
    // act
    index.Object["Key"] = "Value";
    //assert
    index.Verify();
}
