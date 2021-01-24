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
