    sealed class ListComparer : EqualityComparer<List<string>>
    {
      public override bool Equals(List<string> x, List<string> y)
        => StructuralComparisons.StructuralEqualityComparer.Equals(x, y);
    
      public override int GetHashCode(List<string> x)
        => StructuralComparisons.StructuralEqualityComparer.GetHashCode(x);
    }
