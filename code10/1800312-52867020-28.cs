    public static object HandleEnumViaReflection(object e)
    {
       var openType = typeof(ColorConsumer<>);
       var typeToActivate = openType.MakeGenericType(new Type[]{ ColorType });
       var consumer = Activator.CreateInstance(typeToActivate, new object[]{ e });
       return consumer.InstanceColor;
    }
