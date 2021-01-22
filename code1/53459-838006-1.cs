        [Test]
        public void TestCurrencyStrictParsingInAllLocales()
        {
            var originalCulture = CultureInfo.CurrentCulture;
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            const decimal originalNumber = 12345678.98760m;
            var result = new List<string>();
            foreach(var culture in cultures)
            {
                culture.NumberFormat.CurrencySymbol = "";
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                var stringValue = originalNumber.ToString("C4");
                decimal resultNumber = 0;
                if (!DecimalUtils.TryParseCurrency(stringValue, out resultNumber))
                {
                    result.Add(String.Format("Could not convert >{0}< in culture {1}", stringValue, culture.Name));
                } else
                {
                    Assert.AreEqual(originalNumber, resultNumber);
                }
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = originalCulture;
            Assert.AreEqual(2, result.Count, "For some reason, Decimal.Parse cannot parse numbers for ans-AF and tzm-latn-DM.");
            
        }
