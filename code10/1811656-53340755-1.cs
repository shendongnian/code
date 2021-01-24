    [TestMethod]
    public void ReflectionDiscoversBaseClassMethod()
    {
        var inheritedType = typeof(InheritedClass);
        var inheritedTypeMethods = inheritedType.GetMethods(
            BindingFlags.Public | BindingFlags.Instance);
        Assert.IsTrue(inheritedTypeMethods.Any(method => method.Name == "ImplementedMethod"));
    }
