    public static class Extensions {
        public static T With<T,TUpdate>(this T src, TUpdate upd) where T : new() {
            T ans = (T)Activator.CreateInstance(typeof(T));
            var pofs = typeof(T).GetPropertiesOrFields();
            var updpfd = typeof(TUpdate).GetPropertiesOrFields().ToDictionary(pf => pf.Name);
            foreach (var pof in pofs) {
                if (updpfd.TryGetValue(pof.Name, out var updpf))
                    pof.SetValue(ans, updpf.GetValue(upd));
                else
                    pof.SetValue(ans, pof.GetValue(src));
            }
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
