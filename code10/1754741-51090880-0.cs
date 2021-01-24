    // Bar<T> is prepended
    container.Collection.Append(typeof(IFoo<>), typeof(Bar<>));
    // All non-generic registrations next
    container.Collection.Register(typeof(IFoo<>), assemblies);
    // Baz is appended. It will be the last element of the collection
    container.Collection.Append(typeof(IFoo<>), typeof(Baz<>));
