    public class Person(
        [NotNull, NotEmpty] string name,
        [NotNull, NotEmpty] int age
    )
    {
        this.Name = name;
        this.Age = age;
    }
