    public static class AssertExtension {
        public static TExpected AssertIsType<TExpected>(this object actual, string message = null) {
            TExpected result = actual as TExpected;
            Assert.IsNotNull(result, message);
            return result;
        }
    }
