        [Fact]
        public void Test()
        {
            var listGenericParameter = typeof(ClassName);
            var listObjectType = typeof(List<>);
            var constructedListObjectType = listObjectType.MakeGenericType(listGenericParameter);
            var listInstance = Activator.CreateInstance(constructedListObjectType);
            var constructedEnumerableType = typeof(IEnumerable<>).MakeGenericType(listGenericParameter);
            var asQueryableMethod = typeof(Queryable).GetMethod(nameof(Queryable.AsQueryable), new[] { constructedEnumerableType }) ??
                                    throw new InvalidOperationException($"Could not find method AsQueryable() on type {nameof(Queryable)}");
            var listAsQueryable = asQueryableMethod.Invoke(null, new [] { listInstance });
            // method.Invoke('method owner instance', 'method args') 
            // first arg is null because AsQueryable() is extension method = static 
            // => there is no instance "owning" the method (just an owner type)
            (listAsQueryable is IQueryable<ClassName>).Should().BeTrue();
        }
        public class ClassName { }
