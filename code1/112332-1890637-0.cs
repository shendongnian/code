    using System;
    using System.Reflection;
    bool ValidateDelegate(Delegate method, param object[] args)
    {
        ParameterInfo[] parameters = method.Method.GetParameters();
        for (int i = 0; i < parameters.Length; ++i)
        {
            if (parameters[i].ParameterType != args[i].GetType()) { return false; }
        }
        return true;
    }
