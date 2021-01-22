    public class NonOverlappingChildSpec : ISpecification {
      public bool IsSatisfiedBy(Parent parent, Child candidate) {
        return parent.Children.All(child => !Overlaps(child, candidate));
      }
      bool Overlaps(Child c1, Child c2) {
        return c1.ValidFrom <= c2.ValidTo && c2.ValidFrom <= c1.ValidTo;
      }
    }
