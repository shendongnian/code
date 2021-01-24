    //
    // Summary:
    //     Determines whether an instance of a specified type can be assigned to an instance
    //     of the current type.
    //
    // Parameters:
    //   c:
    //     The type to compare with the current type.
    //
    // Returns:
    //     true if any of the following conditions is true: c and the current instance represent
    //     the same type. c is derived either directly or indirectly from the current instance.
    //     c is derived directly from the current instance if it inherits from the current
    //     instance; c is derived indirectly from the current instance if it inherits from
    //     a succession of one or more classes that inherit from the current instance. The
    //     current instance is an interface that c implements. c is a generic type parameter,
    //     and the current instance represents one of the constraints of c. In the following
    //     example, the current instance is a System.Type object that represents the System.IO.Stream
    //     class. GenericWithConstraint is a generic type whose generic type parameter must
    //     be of type System.IO.Stream. Passing its generic type parameter to the System.Type.IsAssignableFrom(System.Type)
    //     indicates that an instance of the generic type parameter can be assigned to an
    //     System.IO.Stream object. System.Type.IsAssignableFrom#2 c represents a value
    //     type, and the current instance represents Nullable<c> (Nullable(Of c) in Visual
    //     Basic). false if none of these conditions are true, or if c is null.
           
           public virtual bool IsAssignableFrom(Type c);
