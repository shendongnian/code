    public static class Utilities {
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
    
        public static IEnumerable<string> GetValueTupleNames(Type source, string action) {
            var method = source.GetMethod(action);
            var attr = method.ReturnParameter.GetCustomAttribute<TupleElementNamesAttribute>();
    
            return attr.TransformNames;
        }
    
        public class MapSource {
            public IEnumerable src { get; }
            public Type srcType { get; }
            public Type methodClass { get; }
            public string methodReturnsTupleName { get; }
    
            public MapSource(IEnumerable src, Type srcType, Type methodClass, string methodReturnsTupleName) {
                this.src = src;
                this.srcType = srcType;
                this.methodClass = methodClass;
                this.methodReturnsTupleName = methodReturnsTupleName;
            }
        }
    
        public static MapSource TupleMapper<VT>(this IEnumerable<VT> src, Type sourceClass, string methodReturnsTupleName) =>
            new MapSource(src, typeof(VT), sourceClass, methodReturnsTupleName);
    
        public static IEnumerable<T> To<T>(this MapSource ms) where T : new() {
            var srcNames = GetValueTupleNames(ms.methodClass, ms.methodReturnsTupleName).Take(ms.srcType.GetFields().Length).ToList();
            var srcMIs = srcNames.Select((Name, i) => new { ItemMI = ms.srcType.GetMember($"Item{i + 1}")[0], i, Name })
                                 .ToDictionary(min => min.Name, min => min.ItemMI);
            var destMIs = srcNames.Select(n => new { members = typeof(T).GetMember(n), Name = n })
                                  .Where(mn => mn.members.Length == 1 && srcMIs[mn.Name].GetMemberType() == mn.members[0].GetMemberType())
                                  .Select(mn => new { DestMI = mn.members[0], mn.Name })
                                  .ToList();
    
            foreach (var s in ms.src) {
                var ans = new T();
                foreach (var MIn in destMIs)
                    MIn.DestMI.SetValue(ans, srcMIs[MIn.Name].GetValue(s));
                yield return ans;
            }
        }
    }
