    var typFactory = typeof(FormFieldFactory<>).MakeGenericType(entity.GetType());
    var methodName = new Func<object, object>(FormFieldFactory<object>.GetPKValue).Method.Name;
    var theMethod =
        (Func<object, object>)Delegate.CreateDelegate(
            typeof(Func<object, object>)
            , typFactory.GetMethod(methodName)
        );
