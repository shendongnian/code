    public interface IValidationRule
    {
        void Validate(string input, out string message);
    }
    [TestMethod]
    public void ValidatorTest()
    {
        Mock<IValidationRule> validatorMock = new Mock<IValidationRule>();
        string outMessage;
        validatorMock
            .Setup(v => v.Validate("input", out outMessage))
            .OutCallback((string i, out string m) => m  = "success");
        string actualMessage;
        validatorMock.Object.Validate("input", out actualMessage);
        Assert.AreEqual("success", actualMessage);
    }
