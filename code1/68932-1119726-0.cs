        [Test]
        [ExpectedException(typeof(RulesException))]
        public void Cannot_Save_Large_Data_In_Color()
        {
            
            var scheme = ColorScheme.Create();
            scheme.Color1 = "1234567890ABCDEF";
            scheme.Validate();
            Assert.Fail("Should have thrown a DataValidationException.");
        }
