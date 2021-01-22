    List<MyObjectA> list = GetAllValues();
    foreach (var item in list)
    {
        switch (item.WrappedType)
        {
            case MyObjecttypeA.Float:
                float f = item.ValueAs<float>();
                // do something with float
        }
    }
