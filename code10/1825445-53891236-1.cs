    public static class Extensions {
        public static T With<T,TUpdate>(this T src, TUpdate upd) where T : new() {
            var ans = new T();
            var srcpfs = typeof(T).GetPropertiesOrFields();
            var updpfd = typeof(TUpdate).GetPropertiesOrFields().ToDictionary(pf => pf.Name);
            foreach (var srcpf in srcpfs)
                    srcpf.SetValue(ans, updpfd.TryGetValue(srcpf.Name, out var updpf) ? updpf.GetValue(upd) : srcpf.GetValue(src));
        
            return ans;
        }
    
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
    }
