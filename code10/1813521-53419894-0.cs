    public static class ExtensionMethods {
        // ***
        // *** IEnumerable<> Extensions
        // ***
        public static DataTable ToDataTable<T>(this IEnumerable<T> rows) {
            var dt = new DataTable();
            if (rows.Any()) {
                var rowType = typeof(T);
                var memberInfos = rowType.GetPropertiesOrFields();
                foreach (var info in memberInfos)
                    dt.Columns.Add(new DataColumn(info.Name, info.GetMemberType()));
    
                foreach (var r in rows)
                    dt.Rows.Add(memberInfos.Select(i => i.GetValue(r)).ToArray());
            }
            return dt;
        }
    
        // ***
        // *** MemberInfo Extensions
        // ***
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
    
        // ***
        // *** Type Extensions
        // ***
        public static List<MemberInfo> GetPropertiesOrFields(this Type t, BindingFlags bf = BindingFlags.Public | BindingFlags.Instance) =>
            t.GetMembers(bf).Where(mi => mi.MemberType == MemberTypes.Field | mi.MemberType == MemberTypes.Property).ToList();
    }
