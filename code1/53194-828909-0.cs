    public static void AreEqual(object expectedValue, object actualValue) {
        if (object.Equals(expectedValue,actualValue)) {
                HttpContext.Current.Response.Write("Equal");
        } else {
                HttpContext.Current.Response.Write("Not Equal");
        }
    }
