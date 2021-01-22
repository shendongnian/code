    public static class TestHelper
    {
        public static void AssertAreEqual(Object expected, Object actual, String name)
        {
            // Start a new check with an empty list of actual objects checked
            // The list of actual objects checked is used to ensure that circular references don't result in infinite recursion
            List<Object> actualObjectsChecked = new List<Object>();
            AssertAreEqual(expected, actual, name, actualObjectsChecked);
        }
        private static void AssertAreEqual(Object expected, Object actual, String name, List<Object> actualObjectsChecked)
        {
            // Just return if already checked the actual object
            if (actualObjectsChecked.Contains(actual))
            {
                return;
            }
            actualObjectsChecked.Add(actual);
            // If both expected and actual are null, they are considered equal
            if (expected == null && actual == null)
            {
                return;
            }
            if (expected == null && actual != null)
            {
                Assert.Fail(String.Format("The actual value of {0} was not null when null was expected.", name));
            }
            if (expected != null && actual == null)
            {
                Assert.Fail(String.Format("The actual value of {0} was null when an instance was expected.", name));
            }
            // Get / check type info
            // Note: GetType always returns instantiated (i.e. most derived) type
            Type expectedType = expected.GetType();
            Type actualType = actual.GetType();
            if (expectedType != actualType)
            {
                Assert.Fail(String.Format("The actual type of {0} was not the same as the expected type.", name));
            }
            // If expected is a Primitive, Value, or IEquatable type, assume Equals is sufficient to check
            // Note: Every IEquatable type should have also overridden Object.Equals
            if (expectedType.IsPrimitive || expectedType.IsValueType || expectedType.IsIEquatable())
            {
                Assert.IsTrue(expected.Equals(actual), "The actual {0} is not equal to the expected.", name);
                return;
            }
            // If expected is an IEnumerable type, assume comparing enumerated items is sufficient to check
            IEnumerable<Object> expectedEnumerable = expected as IEnumerable<Object>;
            IEnumerable<Object> actualEnumerable = actual as IEnumerable<Object>;
            if ((expectedEnumerable != null) && (actualEnumerable != null))
            {
                Int32 actualEnumerableCount = actualEnumerable.Count();
                Int32 expectedEnumerableCount = expectedEnumerable.Count();
                // Check size first
                if (actualEnumerableCount != expectedEnumerableCount)
                {
                    Assert.Fail(String.Format("The actual number of enumerable items in {0} did not match the expected number.", name));
                }
                // Check items in order, assuming order is the same
                for (int i = 0; i < actualEnumerableCount; ++i)
                {
                    AssertAreEqual(expectedEnumerable.ElementAt(i), actualEnumerable.ElementAt(i), String.Format("{0}[{1}]", name, i), actualObjectsChecked);
                }
                return;
            }
            // If expected is not a Primitive, Value, IEquatable, or Ienumerable type, assume comparing properties is sufficient to check
            // Iterate through properties
            foreach (PropertyInfo propertyInfo in actualType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                // Skip properties that can't be read or require parameters
                if ((!propertyInfo.CanRead) || (propertyInfo.GetIndexParameters().Length != 0))
                {
                    continue;
                }
                // Get properties from both
                Object actualProperty = propertyInfo.GetValue(actual, null);
                Object expectedProperty = propertyInfo.GetValue(expected, null);
                AssertAreEqual(expectedProperty, actualProperty, String.Format("{0}.{1}", name, propertyInfo.Name), actualObjectsChecked);
            }
        }
    }
