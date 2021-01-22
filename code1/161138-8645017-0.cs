    var info = System.Reflection.MethodBase.GetCurrentMethod();
    var result = string.Format(
                     "{0}.{1}.{2}()",
                     info.ReflectedType.Namespace,
                     info.ReflectedType.Name,
                     info.Name);
