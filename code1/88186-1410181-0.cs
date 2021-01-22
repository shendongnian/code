    public static class EnumAssert
    {
        public static void AreEquivalent(Type x, Type y)
        {
            // Enum.GetNames and Enum.GetValues return arrays sorted by value.
            var xValues = Enum.GetValues(x);
            var yValues = Enum.GetValues(y);
            Assert.AreEqual(xValues.Length, yValues.Length);
            for (int i = 0; i < xValues.Length; i++)
            {
                var xValue = xValues.GetValue( i );
                var yValue = yValues.GetValue( i );
                Assert.AreEqual(xValue, yValue);
                Assert.AreEqual( Enum.GetName( x, xValue ), Enum.GetName( y, yValue ) );
            }
        }
    }
