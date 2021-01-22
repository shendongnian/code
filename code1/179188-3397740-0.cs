        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            throw new Exception("Assertion does not implement Equals, use Ensure or Require");
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool ReferenceEquals(object objA, object objB)
        {
            throw new Exception("Assertion does not implement ReferenceEquals, use Ensure or Require");
        }
