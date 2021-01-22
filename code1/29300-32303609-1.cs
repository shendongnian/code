        [TestCase(1002, "00:00:01:002")]
        [TestCase(700011, "00:11:40:011")]
        [TestCase(113879834, "07:37:59:834")]
        public void ConvertTime_ResturnsCorrectString(double totalMiliSeconds, string expectedMessage)
        {
            // Arrange
            var obj = new Class();;
            // Act
            var resultMessage = obj.ConvertTime(totalMiliSeconds);
            // Assert
            Assert.AreEqual(expectedMessage, resultMessage);
        }
