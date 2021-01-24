    var ci = action.GetConstructors().First();
    var ciParameters = new List<Object>();
    foreach(var parameter in ci.GetParameters())
    {                  
        ciParameters.Add(serviceProvider.GetService(parameter.ParameterType));
    }
    var t = (IAction)Activator.CreateInstance(action, ciParameters.ToArray());
