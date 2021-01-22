    public class Foo {
        public Person Agent { get; }
    }
    Foo f = getFooFromWhereEver();
    f.Agent.Name.ToString().ToLower();
