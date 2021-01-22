    public class ClassWithNullableProperties
    {
        public int? NullableProp { get; set; }
        public int NonNullableProp { get; set; }
    
        [Test]
        public void NullableProperties()
        {
            PropertyInfo[] typeProperties = GetType().GetProperties();
            var nullableProperties = typeProperties.Where(property => 
             property.PropertyType.IsGenericType &&
             property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
            
            CollectionAssert.AreEquivalent(
                new[] { GetType().GetProperty("NullableProp") },
                nullableProperties.ToArray());
        }
    }
