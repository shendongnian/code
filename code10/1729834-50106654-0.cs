    public static Dictionary<MethodInfo, List<(Type, MethodInfo)>> GetReverseInterfaceMap(Type t)
    {
        var reverseMap = new Dictionary<MethodInfo, List<(Type, MethodInfo)>>();
        var maps = t.GetInterfaces().ToDictionary(i => i, i => t.GetInterfaceMap(i));
        foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            var list = new List<(Type, MethodInfo)>();
            foreach (var (i, map) in maps)
            {
                for (int index = 0; index < map.TargetMethods.Length; index++)
                {
                    var targetMethod = map.TargetMethods[index];
                    if (targetMethod == m)
                    {
                        list.Add((map.InterfaceType, map.InterfaceMethods[index]));
                        break;
                    }
                }
            }
            reverseMap[m] = list;
        }
        return reverseMap;
    }
