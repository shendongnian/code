    public System.Reflection.ConstructorInfo FindStringConstructor()
    {
        Type t = typeof(Foo<string>);
        Type t2 = t.GetGenericTypeDefinition();
        System.Reflection.ConstructorInfo[] cs = t2.GetConstructors();
        for (int i = 0; i < cs.Length; i++)
        {
            if (cs[i].GetParameters()[0].ParameterType == typeof(string))
            {
                return t.GetConstructors()[i];
            }
        }
        return null;
    }
