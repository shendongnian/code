    //
    // Summary:
    //     Verifies that two specified doubles are equal, or within the specified accuracy
    //     of each other. The assertion fails if they are not within the specified accuracy
    //     of each other.
    //
    // Parameters:
    //   expected:
    //     The first double to compare. This is the double the unit test expects.
    //
    //   actual:
    //     The second double to compare. This is the double the unit test produced.
    //
    //   delta:
    //     The required accuracy. The assertion will fail only if expected is different
    //     from actual by more than delta.
    //
    // Exceptions:
    //   Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException:
    //     expected is different from actual by more than delta.
    public static void AreEqual(double expected, double actual, double delta);
