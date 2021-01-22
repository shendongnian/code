    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    /// <summary>
    /// Instantiates an object. Must pass PropertyType.AssemblyQualifiedName for factory to operate
    /// returns instantiated object
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public static object Create(string typeAssemblyQualifiedName)
    {
      // resolve the type
      Type targetType = ResolveType(typeAssemblyQualifiedName);
      if (targetType == null)
        throw new ArgumentException("Unable to resolve object type: " + typeAssemblyQualifiedName);
      return Create(targetType);
    }
    /// <summary>
    /// create by type of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Create<T>()
    {
      Type targetType = typeof(T);
      return (T)Create(targetType);
    }
    /// <summary>
    /// general object creation
    /// </summary>
    /// <param name="targetType"></param>
    /// <returns></returns>
    public static object Create(Type targetType)
    {
      //string test first - it has no parameterless constructor
      if (Type.GetTypeCode(targetType) == TypeCode.String)
        return string.Empty;
      // get the default constructor and instantiate
      Type[] types = new Type[0];
      ConstructorInfo info = targetType.GetConstructor(types);
      object targetObject = null;
      if (info == null) //must not have found the constructor
        if (targetType.BaseType.UnderlyingSystemType.FullName.Contains("Enum"))
          targetObject = Activator.CreateInstance(targetType);
        else
          throw new ArgumentException("Unable to instantiate type: " + targetType.AssemblyQualifiedName + " - Constructor not found");
      else
        targetObject = info.Invoke(null);
      if (targetObject == null)
        throw new ArgumentException("Unable to instantiate type: " + targetType.AssemblyQualifiedName + " - Unknown Error");
      return targetObject;
    }
    /// <summary>
    /// Loads the assembly of an object. Must pass PropertyType.AssemblyQualifiedName for factory to operate
    /// Returns the object type.
    /// </summary>
    /// <param name="typeString"></param>
    /// <returns></returns>
    public static Type ResolveType(string typeAssemblyQualifiedName)
    {
      int commaIndex = typeAssemblyQualifiedName.IndexOf(",");
      string className = typeAssemblyQualifiedName.Substring(0, commaIndex).Trim();
      string assemblyName = typeAssemblyQualifiedName.Substring(commaIndex + 1).Trim();
      if (className.Contains("[]"))
        className.Remove(className.IndexOf("[]"), 2);
      // Get the assembly containing the handler
      Assembly assembly = null;
      try
      {
        assembly = Assembly.Load(assemblyName);
      }
      catch
      {
        try
        {
          assembly = Assembly.LoadWithPartialName(assemblyName);//yes yes this is obsolete but it is only a backup call
        }
        catch
        {
          throw new ArgumentException("Can't load assembly " + assemblyName);
        }
      }
      // Get the handler
      return assembly.GetType(className, false, false);
    }
