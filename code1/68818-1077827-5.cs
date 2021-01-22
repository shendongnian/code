    interface IOne {
       bool Property { get; }
    }
    interface ITwo {
       string Property { get; }
    }
    class Test : IOne, ITwo {
       bool IOne.Property { ... }
       string ITwo.Property { ... }
    }
