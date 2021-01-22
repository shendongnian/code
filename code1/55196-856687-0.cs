    void Foo(Type ty)
    {
        object result = typeof(ContainingClass).GetMethod("Bar").
            .MakeGenericMethod(ty).Invoke(null, new object[] {inputContent});
    }
    public static T Bar<T>(SomeType inputContent) {
        return serializer.Deserialize<T>(inputContent);
    }
