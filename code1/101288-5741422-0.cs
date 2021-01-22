    public class Criteria
    {
     Object Property; // (Domain property, not DB)// (String Or Lambda) Age, Father.Age, Friends, etc
     Object Operator; //(Enum or String)(Eq, Gr, Between,Contains, StartWith, Whatever...)
     Object Value; // (most likely Object, or use generics Criteria<T>), (Guid, int[], Person, any type).
    }
