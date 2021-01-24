    public class JObjectEqualityComparer : IEqualityComparer<JObject>
        {
            public bool Equals(JObject x, JObject y)
            {
                if (x == null && y == null)
                    return true;
                if ((x != null && y == null) || (x == null && y != null))
                    return false;
    
                return JObject.DeepEquals(x, y);
            }
    
            public int GetHashCode(JObject obj)
            {
                JTokenEqualityComparer comparer = new JTokenEqualityComparer();
                int hashCode = comparer.GetHashCode(obj);
                return hashCode;
            }
        }
