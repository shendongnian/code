    public override bool Equals (object obj)
    {
        return Equals(obj as Point2);
    }
    
    public bool Equals (Point2 obj)
    {
        // STEP 1: Check for null if nullable (e.g., a reference type)
        // Note use of ReferenceEquals in case you overload ==.
        if (object.ReferenceEquals(obj, null))
        {
            return false;
        }
        // STEP 2: Check for ReferenceEquals if this is a reference type
        // Skip this or not? With only two fields to check, it's probably
        // not worth it. If the later checks are costly, it could be.
        if (object.ReferenceEquals( this, obj))
        {
            return true;
        }
        // STEP 4: Possibly check for equivalent hash codes
        // Skipped in this case: would be *less* efficient
    
        // STEP 5: Check base.Equals if base overrides Equals()
        // Skipped in this case
        // STEP 6: Compare identifying fields for equality.
        // In this case I'm using == instead of Equals for brevity
        // - assuming X and Y are of a type which overloads ==.
        return this.X == obj.X && this.Y == obj.Y;
    }
