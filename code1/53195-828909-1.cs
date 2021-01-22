    public static void AreEqual<T>(T expectedValue, T actualValue) {
        if (EqualityComparer<T>.Default.Equals(expectedValue,actualValue)) {
                HttpContext.Current.Response.Write("Equal");
        } else {
                HttpContext.Current.Response.Write("Not Equal");
        }
    }
