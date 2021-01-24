    public class ToCurrencyTests
    {
        private string ToCurrency(decimal value, string cultureName) =>
            value.ToCurrency(CultureInfo.GetCultureInfo(cultureName));
        [Theory]
        [MemberData(nameof(enUS))]
        public void Convert_enUS(decimal value, string expected) =>
        Assert.Equal(expected, ToCurrency(value, "en-US"));
        [Theory]
        [MemberData(nameof(frFR))]
        public void Convert_frFR(decimal value, string expected) =>
            Assert.Equal(expected, ToCurrency(value, "fr-FR"));
        public static TheoryData<decimal, string> enUS =>
            new TheoryData<decimal, string>
            {
                { 1m, "$1" },
                { 1.0m, "$1" },
                { 1.1m, "$1.1" },
                { 1.10m, "$1.1" },
                { -1m, "($1)" },
                { -1.0m, "($1)" },
                { -1.1m, "($1.1)" },
                { 1000m, "$1,000" },
                { 1000.0m, "$1,000" },
                { 123456789.123456789m, "$123,456,789.123456789" },
                { .0000000000000000000000000001m, "$0.0000000000000000000000000001" }
            };
        /// <remarks>
        ///     Note that the group separator used here is a non-breaking space ' ' (i.e. &nbsp; or char 160)
        /// </remarks>
        public static TheoryData<decimal, string> frFR =>
            new TheoryData<decimal, string>
            {
                { 1m, "1 €" },
                { 1.0m, "1 €" },
                { 1.1m, "1,1 €" },
                { 1.10m, "1,1 €" },
                { -1m, "-1 €" },
                { -1.0m, "-1 €" },
                { -1.1m, "-1,1 €" },
                { 1000m, "1 000 €" },
                { 1000.0m, "1 000 €" },
                { 123456789.123456789m, "123 456 789,123456789 €" },
                { .0000000000000000000000000001m, "0,0000000000000000000000000001 €" }
            };
    }
