    public void MyFunction (Type input)
    {
       Contract.Requires(input > SomeReferenceValue);
       Contract.Requires (input < SomeOtherReferencValue);
    
    }
