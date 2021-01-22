    public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
    {
        ConstructorInfo ctor = _type.GetConstructor(args.Select(arg => arg.GetType()).ToArray());
        if (ctor == null)
        {
            result = null;
            return false;
        }
        result = ctor.Invoke(args);
        return true;
    }
