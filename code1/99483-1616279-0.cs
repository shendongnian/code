            // A lambda solution
            Func<object, object> fnGetValue =
                v =>
                    ReferenceEquals(v, null)
                    ? DBNull.Value
                    : v;
            // Sample usage
            int? one = 1;
            int? two = null;
            object o1 = fnGetValue(one); // gets 1
            object o2 = fnGetValue(two); // gets DBNull
