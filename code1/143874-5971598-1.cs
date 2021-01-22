    public class TypeNameStringExtensions
    {
        public static string GetCSharpRepresentation(Type t)
        {
            return GetCSharpRepresentation(t, new Queue<Type>(t.GetGenericArguments()));
        }
        static string GetCSharpRepresentation(Type t, Queue<Type> availableArguments)
        {
            string value = t.Name;
            if (t.IsGenericParameter)
            {
                return value;
            }
            if (t.DeclaringType != null)
            {
                // This is a nested type, build the parent type first
                value = GetCSharpRepresentation(t.DeclaringType, availableArguments) + "+" + value;
            }
            if (t.IsGenericType)
            {
                value = value.Split('`')[0];
                // Build the type arguments (if any)
                string argString = "";
                var thisTypeArgs = t.GetGenericArguments();
                for (int i = 0; i < thisTypeArgs.Length && availableArguments.Count > 0; i++)
                {
                    if (i != 0) argString += ", ";
                    argString += GetCSharpRepresentation(availableArguments.Dequeue());
                }
                // If there are type arguments, add them with < >
                if (argString.Length > 0)
                {
                    value += "<" + argString + ">";
                }
            }
            return value;
        }
        [TestCase(typeof(List<string>), "List<String>")]
        [TestCase(typeof(List<Dictionary<int, string>>), "List<Dictionary<Int32, String>>")]
        [TestCase(typeof(Stupid<int>.Stupider<int>), "Stupid<Int32>+Stupider<Int32>")]
        [TestCase(typeof(Dictionary<int, string>.KeyCollection), "Dictionary<Int32, String>+KeyCollection")]
        [TestCase(typeof(Nullable<Point>), "Nullable<Point>")]
        [TestCase(typeof(Point?), "Nullable<Point>")]
        [TestCase(typeof(TypeNameStringExtensions), "TypeNameStringExtensions")]
        [TestCase(typeof(Another), "TypeNameStringExtensions+Another")]
        [TestCase(typeof(G<>), "TypeNameStringExtensions+G<T>")]
        [TestCase(typeof(G<string>), "TypeNameStringExtensions+G<String>")]
        [TestCase(typeof(G<Another>), "TypeNameStringExtensions+G<TypeNameStringExtensions+Another>")]
        [TestCase(typeof(H<,>), "TypeNameStringExtensions+H<T1, T2>")]
        [TestCase(typeof(H<string, Another>), "TypeNameStringExtensions+H<String, TypeNameStringExtensions+Another>")]
        [TestCase(typeof(Another.I<>), "TypeNameStringExtensions+Another+I<T3>")]
        [TestCase(typeof(Another.I<int>), "TypeNameStringExtensions+Another+I<Int32>")]
        [TestCase(typeof(G<>.Nested), "TypeNameStringExtensions+G<T>+Nested")]
        [TestCase(typeof(G<string>.Nested), "TypeNameStringExtensions+G<String>+Nested")]
        [TestCase(typeof(A<>.C<>), "TypeNameStringExtensions+A<B>+C<D>")]
        [TestCase(typeof(A<int>.C<string>), "TypeNameStringExtensions+A<Int32>+C<String>")]
        public void GetCSharpRepresentation_matches(Type type, string expected)
        {
            string actual = GetCSharpRepresentation(type);
            Assert.AreEqual(expected, actual);
        }
        public class G<T>
        {
            public class Nested { }
        }
        public class A<B>
        {
            public class C<D> { }
        }
        public class H<T1, T2> { }
        public class Another
        {
            public class I<T3> { }
        }
    }
    public class Stupid<T1>
    {
        public class Stupider<T2>
        {
        }
    }
