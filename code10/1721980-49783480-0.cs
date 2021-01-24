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
