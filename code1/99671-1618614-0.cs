    class Person : IReadOnlyPerson {
        public string Name { get; set; }
    }
    public interface IReadOnlyPerson {
        string Name { get; }
    }
