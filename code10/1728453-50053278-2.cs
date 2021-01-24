    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TestConsoleProject;
    namespace UnitTestProject
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestFormatter_WithoutBrackets()
            {
                // Arrange
                var reader = new WeirdLineFormatReader();
                string[] lines = {
                    "field20D.name = Reference"
                };
                // Act
                var tuples = reader.ReadLines(lines).ToList();
                // Assert
                Assert.AreEqual(tuples[0].Item1, "20D", "Field 20D did not format correctly, Actual:" + tuples[0].Item1);
                Assert.AreEqual(tuples[0].Item2, "Reference", "Field 20D's description did not format correctly, Actual:" + tuples[0].Item2);
            }
            [TestMethod]
            public void TestFormatter_WithBrackets()
            {
                // Arrange
                var reader = new WeirdLineFormatReader();
                string[] lines = {
                    "field20[103].name = Sender's Reference"
                };
                // Act
                var tuples = reader.ReadLines(lines).ToList();
                // Assert
                Assert.AreEqual(tuples[0].Item1, "20[103]", "Field 20[103] did not format correctly, Actual:" + tuples[0].Item1);
                Assert.AreEqual(tuples[0].Item2, "Sender's Reference", "Field 20[103]'s description did not format correctly, Actual:" + tuples[0].Item2);
            }
        }
    }
