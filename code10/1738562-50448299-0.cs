    [TestClass]
    public class BirdEyeViewColumnWidthConverterTests
    {
        [TestMethod]
        public void BirdEyeViewColumnWidthConverterTest()
        {
            const int BirdEyeModeWidth = 20;
            const int DefaultWidth = 10;
            BirdEyeViewColumnWidthConverter converter = new BirdEyeViewColumnWidthConverter()
            {
                BirdEyeModeWidth = BirdEyeModeWidth,
                DefaultWidth = DefaultWidth,
            };
            int convertedValue = (int)converter.Convert(true, typeof(int), null, CultureInfo.InvariantCulture);
            Assert.AreEqual(BirdEyeModeWidth, convertedValue);
            convertedValue = (int)converter.Convert(false, typeof(int), null, CultureInfo.InvariantCulture);
            Assert.AreEqual(DefaultWidth, convertedValue);
        }
    }
