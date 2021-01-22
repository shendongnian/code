    void Method(IEnumerable source)
    {
        var enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
        {
            MethodInfo method = typeof(MyClass).GetMethod("Method2");
            MethodInfo generic;
            Type type = enumerator.Current.GetType();
            bool sameType = true;
            
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.GetType() != type)
                {
                    sameType = false;
                    break;
                }
            }
            if (sameType)
                generic = method.MakeGenericMethod(type);
            else
                generic = method.MakeGenericMethod(typeof(object));
            generic.Invoke(this, new object[] { source });
        }
    }
