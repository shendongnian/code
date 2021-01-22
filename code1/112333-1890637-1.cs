    using System;
    using System.Reflection;
    bool ValidateDelegate(Delegate method, params object[] args)
    {
        ParameterInfo[] parameters = method.Method.GetParameters();
        if (parameters.Length != args.Length) { return false; }
        for (int i = 0; i < parameters.Length; ++i)
        {
            if (parameters[i].ParameterType.IsAssignableFrom(args[i].GetType()))
            { return false; }
        }
        return true;
    }
