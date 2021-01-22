     [DataContract()]
     public class Immutable
     {
          [DataMember(IsRequired=true)]
          public readonly string Member;
          public Immutable(string member)
          {
               Member = member;
          }
     }
