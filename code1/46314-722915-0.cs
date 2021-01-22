    public static class PermutationGenerator
    {
        private static class Permutation<T>
        {
            public static IEnumerable<T> Choices { get; set; }
        }
        static PermutationGenerator()
        {
            Permutation<int>.Choices = new List<int> { -1, 0, 1 }.AsReadOnly();
            Permutation<string>.Choices = new List<string> { null, "", "Hello World" }.AsReadOnly();
        }
        public static IEnumerable<T> GetPermutations<T>()
        {
            if (Permutation<T>.Choices == null) {
                var props = typeof(T).GetProperties().Where(p => p.CanWrite);
                Permutation<T>.Choices = new List<T>(GeneratePermutations<T>(() => Activator.CreateInstance<T>(), props)).AsReadOnly();
            }
            return Permutation<T>.Choices;
        }
        private static IEnumerable GetPermutations(Type t) {
            var method = typeof(PermutationGenerator).GetMethod("GetPermutations", new Type[] {}).MakeGenericMethod(t);
            return (IEnumerable)(method.Invoke(null,new object[] {}));
        }
        private delegate T Generator<T>();
        private static IEnumerable<T> GeneratePermutations<T>(Generator<T> generator, IEnumerable<PropertyInfo> props)
        {
            if (!props.Any())
            {
                yield return generator();
            }
            else
            {
                var prop = props.First();
                var rest = props.Skip(1);
                foreach (var propVal in GetPermutations(prop.PropertyType))
                {
                    Generator<T> gen = () =>
                    {
                        var obj = generator();
                        prop.SetValue(obj, propVal, null);
                        return (T)obj;
                    };
                    foreach (var result in GeneratePermutations(gen, rest))
                    {
                        yield return result;
                    }
                }
            }
        }
    }
