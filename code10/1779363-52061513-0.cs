    public class CS3DComparer : IEqualityComparer {
        public bool Equals(CS3DLines a, CS3DLines b) {
            return IsSameLineIn3D(a, b);
        }
        public int GetHashCode(CS3DLines line){
            // You do not need to use all properties of line to calculate the 
            // hashCode. If performance is not good enough you can experiment by 
            // adding and removing properties from the hash code calculation.
            
            var hashCode = line.Property1?.GetHashCode() ?? 0;
            hashCode = (hashCode * 397) ^ (line.Property2?.GetHashCode() ?? 0);
            hashCode = (hashCode * 397) ^ (line.Property3?.GetHashCode() ?? 0);
            return hashCode;
        }
    }
