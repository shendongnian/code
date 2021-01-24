    public class MockCreator
    {
        public static Mock CreateMock(Type genericType, Type itemType)
        {
            var typeToMock = genericType.MakeGenericType(itemType);
            var creator = typeof(Mock<>).MakeGenericType(typeToMock);
            return (Mock)Activator.CreateInstance(creator);
        }
    }
    // Usage
    var types = new Type[0]; // Your entity types
    var sets = types.Select(t => MockCreator.CreateMock(typeof(DbSet<>), t)).ToList();
    // Or in your case 
    var setMock = MockCreator.CreateMock(typeof(DbSet<>), basisdataInstance.GetType());
