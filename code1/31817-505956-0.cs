    public class XElementComparer : IEqualityComparer‹XElement› {
       public bool Equals(XElement x, XElement y) {
         return ‹X and Y are equal according to your standards›;
    }
   
     public int GetHashCode(XElement obj) {
         return ‹hash code based on whatever parameters you used to determine        
                Equals. For example, if you determine equality based on the ID 
                attribute, return the hash code of the ID attribute.›;
   
     }
     }
