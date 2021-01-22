    class Entity {
        public virtual IEnumerable<string> Attributes { get { yield return "Name"; } }
    }
    class Person : Entity {
        public override IEnumerable<string> Attributes {
            get {
                return new string[] { "FirstName", "LastName" }
                    .Concat(base.Attributes);
            }
        }
    }
    class User : Person {
        public override IEnumerable<string> Attributes {
            get {
                return new string[] { "UserName" }
                    .Concat(base.Attributes);
            }
        }
    }
