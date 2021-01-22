        [Test]
        public void TestCurrencyStrictParsingInAllLocales()
        {
            var originalCulture = CultureInfo.CurrentCulture;
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            const decimal originalNumber = 12345678.98m;
            foreach(var culture in cultures)
            {
                var stringValue = originalNumber.ToCurrencyWithoutSymbolFormat();
                decimal resultNumber = 0;
                Assert.IsTrue(DecimalUtils.TryParseCurrency(stringValue, out resultNumber));
                Assert.AreEqual(originalNumber, resultNumber);
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = originalCulture;
            
        }
