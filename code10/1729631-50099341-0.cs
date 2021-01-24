    public interface IMockCreator
    {
        object MakeMock();
    }
    public class MockCreator
    {
        private class GenericCreator<T> : IMockCreator
            where T : class 
        {
            public object MakeMock()
            {
                var mock = new Mock<T>();
                return mock.Object;
            }
        }
        public static IMockCreator MakeCreator(Type genericType, Type itemType)
        {
            var typeToMock = genericType.MakeGenericType(itemType);
            var creator = typeof(GenericCreator<>).MakeGenericType(typeToMock);
            return (IMockCreator) Activator.CreateInstance(creator);
        }
    }
    // Usage
    var types = new Type[0]; // Your entity types
    var sets = types.Select(t => MockCreator.MakeCreator(typeof(DbSet<>), t).MakeMock()).ToList();
