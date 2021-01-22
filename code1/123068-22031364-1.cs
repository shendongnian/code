    public static bool IsCastableTo(this Type from, Type to, bool implicitly = false)
    {
        return to.IsAssignableFrom(from) || from.HasCastDefined(to, implicitly);
    }
    static bool HasCastDefined(this Type from, Type to, bool implicitly)
    {
        if ((from.IsPrimitive || from.IsEnum) && (to.IsPrimitive || to.IsEnum))
        {
            if (!implicitly) return true;
    
            Type[][] typeHierarchy = {
                new Type[] { typeof(Boolean), typeof(Byte), typeof(SByte), typeof(Char) },
                new Type[] { typeof(Int16), typeof(UInt16) },
                new Type[] { typeof(Int32), typeof(UInt32) },
                new Type[] { typeof(Int64), typeof(UInt64) },
                new Type[] { typeof(Single) },
                new Type[] { typeof(Double) }
            };
            IEnumerable<Type> lowerTypes = Enumerable.Empty<Type>();
            foreach (Type[] types in typeHierarchy)
            {
                if ( types.Any(t => t == to) )
                    return lowerTypes.Any(t => t == from);
                lowerTypes = lowerTypes.Concat(types);
            }
    
            return false;   // IntPtr, UIntPtr, Enum
        }
        return IsCastDefined(to, m => m.GetParameters()[0].ParameterType, _ => from, implicitly, false)
            || IsCastDefined(from, _ => to, m => m.ReturnType, implicitly, true);
    }
    static bool IsCastDefined(Type type, Func<MethodInfo, Type> baseType,
                            Func<MethodInfo, Type> derivedType, bool implicitly, bool lookInBase)
    {
        var bindinFlags = BindingFlags.Public | BindingFlags.Static
                        | (lookInBase ? BindingFlags.FlattenHierarchy : BindingFlags.DeclaredOnly);
        return type.GetMethods(bindinFlags).Any(
            m => (m.Name=="op_Implicit" || (!implicitly && m.Name=="op_Explicit"))
                && baseType(m).IsAssignableFrom(derivedType(m)));
    }
