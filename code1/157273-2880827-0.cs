    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DynamicSwitchAttribute : Attribute
    {
     public DynamicSwitchAttribute(Type enumType, params object[] targets) { Targets = new HashSet<object>(targets); EnumType = enumType; }
     public Type EnumType { get; private set; }
     public HashSet<object> Targets { get; private set; }
    }
    //this builds a cache of methods for a given TTarget type, with a signature equal to TAction,
    //keyed by values of the type TEnum.  All methods are expected to be instance methods.
    //this code can easily be modified to support static methods instead.
    //what would be nice here is if we could enforce a generic constraint on TAction : Delegate, but
    //we can't.
    public static class DynamicSwitch<TTarget, TEnum, TAction>
    {
     //our lookup of actions against enum values.
     //note: no lock is required on this as it is built when the static class is initialised.
     private static Dictionary<TEnum, TAction> _actions = new Dictionary<TEnum, TAction>();
     private static MethodInfo _tActionMethod;
     private static MethodInfo TActionMethod
     {
      get
      {
       if (_tActionMethod == null)
       {
        //one criticism of this approach might be that validation exceptions will be thrown
        //inside a TypeInitializationException.
        _tActionMethod = typeof(TAction).GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public);
        if (_tActionMethod == null)
         throw new ArgumentException(string.Format("The generic parameter type {0} is not a delegate type", typeof(TAction).FullName));
        //verify that the first parameter type is compatible with our TTarget type.
        var methodParams = _tActionMethod.GetParameters();
        if (methodParams.Length == 0)
         throw new ArgumentException(string.Format("At least one argument of type {0} (or one of it's bases) is expected in the TAction delegate", typeof(TTarget).FullName));
        //now check that the first parameter is compatible with our type TTarget
        if (!methodParams[0].ParameterType.IsAssignableFrom(typeof(TTarget)))
         throw new ArgumentException(string.Format("The first parameter of the delegate type {0} is not compatible with the target type {1}", typeof(TAction).FullName, typeof(TTarget).FullName));
       }
       return _tActionMethod;
      }
     }
     static DynamicSwitch()
     {
      //examine the type TTarget to extract all public instance methods (you can change this to private instance if need be)
      //which have a DynamicSwitchAttributes defined.
      //we then project the attributes and the method into an anonymous type
      var possibleMatchingMethods = from method in typeof(TTarget).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                     let attributes = method.GetCustomAttributes(typeof(DynamicSwitchAttribute), true).Cast<DynamicSwitchAttribute>().ToArray()
                     where attributes!= null && attributes.Length == 1 && attributes[0].EnumType.Equals(typeof(TEnum))
                     select new { Method = method, Attribute = attributes[0] };
      //create linq expression parameter expressions for each of the delegate type's parameters
      //these can be re-used for each of the dynamic methods we generate.
      ParameterExpression[] paramExprs = TActionMethod.GetParameters().Select((pinfo, index) =>
       Expression.Parameter(pinfo.ParameterType, pinfo.Name ?? string.Format("arg{0}"))).ToArray();
      //pre-build an array of these parameter expressions that only include the actual parameters
      //for the method, and not the 'this' parameter.
      ParameterExpression[] realParamExprs = paramExprs.Skip(1).ToArray();
      //this has to be generated for each target method.
      MethodCallExpression methodCall = null;
      foreach (var match in possibleMatchingMethods)
      {
       if (!MethodMatchesAction(match.Method))
        continue;
       //right, now we're going to use System.Linq.Expressions to build a dynamic expression to invoke this method
       //given an instance of TTarget.
       methodCall = Expression.Call(Expression.Convert(paramExprs[0], typeof(TTarget)), match.Method, realParamExprs);
       TAction dynamicDelegate = Expression.Lambda<TAction>(methodCall, paramExprs).Compile();
       //now we have our method, we simply inject it into the dictionary, using all the unique TEnum values (from the attribute) 
       //as the keys
       foreach (var enumValue in match.Attribute.Targets.OfType<TEnum>())
       {
        if (_actions.ContainsKey(enumValue))
         throw new InvalidOperationException(string.Format("The value {0} is mapped more than once", enumValue));
        _actions[enumValue] = dynamicDelegate;
       }
      }
     }
     private static bool MethodMatchesAction(MethodInfo method)
     {
      //so we want to check that the target method matches our desired delegate type (TAction).
      //The way this is done is to fetch the delegate type's Invoke method (implicitly invoked when
      //you invoke delegate(args)), and then we check the return type and parameters types of that
      //against the return type and args of the method we've been passed.
      //if the target method's return type is equal to or derived from the expected delegate's return type,
      //then all is good.
      if (!_tActionMethod.ReturnType.IsAssignableFrom(method.ReturnType))
       return false;
      //now, the parameter lists of the method will not be equal in length, as our delegate explicitly
      //includes the 'this' parameter, whereas instance methods do not.
      var methodParams = method.GetParameters();
      var delegateParams = TActionMethod.GetParameters();
      for (int i = 0; i < methodParams.Length; i++)
      {
       if (!methodParams[i].ParameterType.IsAssignableFrom(delegateParams[i + 1].ParameterType))
        return false;
      }
      return true;
     }
     public static TAction Resolve(TEnum value)
     {
      TAction result;
      if (!_actions.TryGetValue(value, out result))
       throw new ArgumentException("The value is not mapped");
      return result;
     }
    }
