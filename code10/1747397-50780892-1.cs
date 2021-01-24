    public class Entity : EntityBase {
       protected override object Keys {
          get {
             return SomeKeyProperty;//suppose this is a long property
          }
       }
       protected override object EmptyKeys {
          get {
             return 0L;//here 0 value should also be a long value.
          }
       }
    }
