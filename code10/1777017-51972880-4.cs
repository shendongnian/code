        public class Parent
        {
            public virtual IEnumerable<Parent> ListOf { get; set; } = new List<Parent>();
        }
        public class Child : Parent
        {
            public override IEnumerable<Parent> ListOf { get; set; } = new List<Child>();
        }
