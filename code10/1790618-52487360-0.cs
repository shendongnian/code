    // ***
    // *** Type Extensions
    // ***
    public static List<MemberInfo> GetPropertiesOrFields(this Type t, BindingFlags bf = BindingFlags.Public | BindingFlags.Instance) =>
        t.GetMembers(bf).Where(mi => mi.MemberType == MemberTypes.Field | mi.MemberType == MemberTypes.Property).ToList();
    // ***
    // *** MemberInfo Extensions
    // ***
    public static object GetValue(this MemberInfo member, object srcObject) {
        switch (member) {
            case FieldInfo mfi:
                return mfi.GetValue(srcObject);
            case PropertyInfo mpi:
                return mpi.GetValue(srcObject);
            default:
                throw new ArgumentException("MemberInfo must be of type FieldInfo or PropertyInfo", nameof(member));
        }
    }
    public static T GetValue<T>(this MemberInfo member, object srcObject) => (T)member.GetValue(srcObject);
    public static void SetValue<T>(this MemberInfo member, object destObject, T value) {
        switch (member) {
            case FieldInfo mfi:
                mfi.SetValue(destObject, value);
                break;
            case PropertyInfo mpi:
                mpi.SetValue(destObject, value);
                break;
            default:
                throw new ArgumentException("MemberInfo must be of type FieldInfo or PropertyInfo", nameof(member));
        }
    }
    public static Type GetMemberType(this MemberInfo member) {
        switch (member) {
            case FieldInfo mfi:
                return mfi.FieldType;
            case PropertyInfo mpi:
                return mpi.PropertyType;
            case EventInfo mei:
                return mei.EventHandlerType;
            default:
                throw new ArgumentException("MemberInfo must be if type FieldInfo, PropertyInfo or EventInfo", nameof(member));
        }
    }
    public static bool GetCanWrite(this MemberInfo member) {
        switch (member) {
            case FieldInfo mfi:
                return true;
            case PropertyInfo mpi:
                return mpi.CanWrite;
            default:
                throw new ArgumentException("MemberInfo must be if type FieldInfo or PropertyInfo", nameof(member));
        }
    }
