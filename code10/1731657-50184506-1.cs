    public static class Ext {
        public static bool HasDeclaredEquals(this object obj) =>
            typeof(IEquatable<>).MakeGenericType(obj.GetType())
                                .IsAssignableFrom(obj.GetType());
    }
    
    public class JSONCollectionComparer : IEqualityComparer {
        public new bool Equals(object x, object y) {
            var c = new JSONComparer();
    
            var xc = x as ICollection;
            var yc = y as ICollection;
            
            if (xc.Count != yc.Count)
                return false;
    
            var ans = true;
            foreach (var xyv in xc.Cast<object>().Zip(yc.Cast<object>(), (xv, yv) => (xv, yv))) {
                ans = ans && c.Equals(xyv.xv, xyv.yv);
                if (!ans)
                    break;
            }
    
            return ans;
        }
    
        public int GetHashCode(object obj) {
            throw new NotImplementedException();
        }
    }
    
    public class JSONComparer : IEqualityComparer {
        public new bool Equals(object x, object y) {
            JSONComparer jc = null;
            JSONCollectionComparer jac = null;
            var ans = true;
    
            var members = x.GetType().GetMembers().Where(m => m is PropertyInfo || m is FieldInfo);
            foreach (var m in members) {
                var mType = m.GetMemberType();
                var xv = m.GetValue(x);
                var yv = m.GetValue(y);
                if (xv != null && yv != null)
                    if (xv.HasDeclaredEquals())
                        ans = ans && xv.Equals(yv);
                    else {
                        switch (xv) {
                            case ICollection xc:
                                jac = jac ?? new JSONCollectionComparer();
                                ans = ans && jac.Equals(xv, yv);
                                break;
                            default:
                                jc = jc ?? new JSONComparer();
                                ans = ans && jc.Equals(xv, yv); ;
                                break;
                        }
                    }
                if (!ans)
                    break;
            }
    
            return ans;
        }
    
        public int GetHashCode(object obj) {
            throw new NotImplementedException();
        }
    }
