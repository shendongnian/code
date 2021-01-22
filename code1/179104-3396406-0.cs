    public static class Extensions
    {
            public static void ThrowIfArgumentIsNull<T>(this T obj, string parameterName) where T : class
            {
                    if (obj == null) throw new ArgumentNullException(parameterName + " not allowed to be null");
            }
    }
    internal class Test
    {
            public Test(string input1)
            {
                    input1.ThrowIfArgumentIsNull("input1");
            }
    }
