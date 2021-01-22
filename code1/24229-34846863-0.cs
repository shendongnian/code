    public static bool AssertObjects<T>(T expectInput, T actualInput)
        {
            // If T is primitive type.
            if (typeof(T).IsPrimitive)
            {
                if (expectInput.Equals(actualInput))
                {
                    return true;
                }
                return false;
            }
            // If T is implement IEnumerable.
            if (expectInput is IEnumerable)
            {
                var expectEnumerator = ((IEnumerable)expectInput).GetEnumerator();
                var actualEnumerator = ((IEnumerable)actualInput).GetEnumerator();
                var canGetExpectMember = expectEnumerator.MoveNext();
                var canGetActualMember = actualEnumerator.MoveNext();
                while (canGetExpectMember && canGetActualMember && true)
                {
                    var currentType = expectEnumerator.Current.GetType();
                    object isEqual = typeof(Utils).GetMethod("AssertObjects").MakeGenericMethod(currentType).Invoke(null, new object[] { expectEnumerator.Current, actualEnumerator.Current });
                    if ((bool)isEqual == false)
                    {
                        return false;
                    }
                    canGetExpectMember = expectEnumerator.MoveNext();
                    canGetActualMember = actualEnumerator.MoveNext();
                }
                if (canGetExpectMember != canGetActualMember)
                {
                    return false;
                }
                return true;
            }
            // If T is class.
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var expectValue = typeof(T).GetProperty(property.Name).GetValue(expectInput);
                var actualValue = typeof(T).GetProperty(property.Name).GetValue(actualInput);
                if (expectValue == null || actualValue == null)
                {
                    if (expectValue == null && actualValue == null)
                    {
                        continue;
                    }
                    return false;
                }
                object isEqual = typeof(Utils).GetMethod("AssertObjects").MakeGenericMethod(property.PropertyType).Invoke(null, new object[] { expectValue, actualValue });
                if ((bool)isEqual == false)
                {
                    return false;
                }
            }
            return true;
        }
