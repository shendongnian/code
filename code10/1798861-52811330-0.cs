    class Base
    {
       protected int A { get; set; }
    }
    
    class DerivedA : Base
    {
       protected sealed override int A { get => base.A; set => base.A = value; }
    }
    
    class DerivedB : DerivedA
    {
       // Attempting to override A causes compiler error.
    }
