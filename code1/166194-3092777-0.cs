    class Person {
       [Flags]
       public enum EnumRole {
          None = 0,
          Actor,
          Director,
          Producer,
          Writer
       }
    
       public Person( EnumRole role ) {
          Role = role;
       }
    
       public EnumRole Role { get; set; }
    
       public bool CanDo( EnumRole role ) {
          return (Role & role) != EnumRole.None;
       }
    }
