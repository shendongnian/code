    protected bool ValidAdvert(Base item)
    {
        if (item.GetType() == typeof(Base))
            throw new ThisIsAnAbstractClassException();
        Type type = typeof(CurrentClass);
        MethodInfo method = type.GetMethod("ValidAdvert",
                                           BindingFlags.Instance | BindingFlags.NonPublic,
                                           null,
                                           new Type[] { item.GetType() },
                                           null);
        return method.Invoke(this, item);
    }
    protected bool ValidAdvert(Derived1 item)
    {
        return ADerived1SpecificPredicate;
    }
    protected bool ValidAdvert(Derived2 item)
    {
        return ADerived2SpecificPredicate;
    }
