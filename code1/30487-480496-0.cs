    // Single dispatch
    Object o = GetSomeObject(); // Return SomeType casted to Object.
    o.ToString(); // Call SomeType::ToString instead of just Object::ToString
    // Double dispatch (this version won't work in C#)
    Shape s1 = GetSquare();
    Shape s2 = GetCircle();
    s1.Intersects(s2); // If C# supported double dispatch, this would call Square::Intersects(Circle) not Square::Intersects(Shape)
    
