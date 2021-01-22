        /// <summary>
        /// Tests to make sure that the correct type is return.
        /// </summary>
        [Test(Description = "Tests to make sure that the correct type is return.")]
        public void Test_GetTheType()
        {
            var value = string.Empty;
            var theType = value.GetTheType();
            Assert.That(theType, Is.SameAs(typeof(string)));
        }
        /// <summary>
        /// Tests to make sure that the correct type is returned even if the value is null.
        /// </summary>
        [Test(Description = "Tests to make sure that the correct type is returned even if the value is null.")]
        public void Test_GetTheType_ReturnsTypeEvenIfValueIsNull()
        {
            string value = null;
            var theType = value.GetTheType();
            Assert.That(theType, Is.SameAs(typeof(string)));
        }
