    class Person { }
    abstract class Student : Person
    {
        public abstract decimal Wage { get; }
    }
    abstract class Musician : Person
    {
        public abstract decimal Wage { get; }
    }
    class StudentMusician : Person
    {
        public decimal MusicianWage { get { return 10; } }
        public decimal StudentWage { get { return 8; } }
        public Musician AsMusician() { return new MusicianFacade(this); }
        public Student AsStudent() { return new StudentFacade(this); }
    }
