        /// <summary>
        /// Get the ordinal value of positive integers.
        /// </summary>
        /// <remarks>
        /// Only works for english-based cultures.
        /// Code from: http://stackoverflow.com/questions/20156/is-there-a-quick-way-to-create-ordinals-in-c/31066#31066
        /// With help: http://www.wisegeek.com/what-is-an-ordinal-number.htm
        /// </remarks>
        /// <param name="number">The number.</param>
        /// <returns>Ordinal value of positive integers, or <see cref="int.ToString"/> if less than 1.</returns>
        public static string Ordinal(this int number)
        {
            const string TH = "th";
            string s = number.ToString();
            // Negative and zero have no ordinal representation
            if (number < 1)
            {
                return s;
            }
            number %= 100;
            if ((number >= 11) && (number <= 13))
            {
                return s + TH;
            }
            switch (number % 10)
            {
                case 1: return s + "st";
                case 2: return s + "nd";
                case 3: return s + "rd";
                default: return s + TH;
            }
        }
        [Test]
        public void Ordinal_ReturnsExpectedResults()
        {
            Assert.AreEqual("-1", (1-2).Ordinal());
            Assert.AreEqual("0", 0.Ordinal());
            Assert.AreEqual("1st", 1.Ordinal());
            Assert.AreEqual("2nd", 2.Ordinal());
            Assert.AreEqual("3rd", 3.Ordinal());
            Assert.AreEqual("4th", 4.Ordinal());
            Assert.AreEqual("5th", 5.Ordinal());
            Assert.AreEqual("6th", 6.Ordinal());
            Assert.AreEqual("7th", 7.Ordinal());
            Assert.AreEqual("8th", 8.Ordinal());
            Assert.AreEqual("9th", 9.Ordinal());
            Assert.AreEqual("10th", 10.Ordinal());
            Assert.AreEqual("11th", 11.Ordinal());
            Assert.AreEqual("12th", 12.Ordinal());
            Assert.AreEqual("13th", 13.Ordinal());
            Assert.AreEqual("14th", 14.Ordinal());
            Assert.AreEqual("20th", 20.Ordinal());
            Assert.AreEqual("21st", 21.Ordinal());
            Assert.AreEqual("22nd", 22.Ordinal());
            Assert.AreEqual("23rd", 23.Ordinal());
            Assert.AreEqual("24th", 24.Ordinal());
            Assert.AreEqual("100th", 100.Ordinal());
            Assert.AreEqual("101st", 101.Ordinal());
            Assert.AreEqual("102nd", 102.Ordinal());
            Assert.AreEqual("103rd", 103.Ordinal());
            Assert.AreEqual("104th", 104.Ordinal());
            Assert.AreEqual("110th", 110.Ordinal());
            Assert.AreEqual("111th", 111.Ordinal());
            Assert.AreEqual("112th", 112.Ordinal());
            Assert.AreEqual("113th", 113.Ordinal());
            Assert.AreEqual("114th", 114.Ordinal());
            Assert.AreEqual("120th", 120.Ordinal());
            Assert.AreEqual("121st", 121.Ordinal());
            Assert.AreEqual("122nd", 122.Ordinal());
            Assert.AreEqual("123rd", 123.Ordinal());
            Assert.AreEqual("124th", 124.Ordinal());
        }
