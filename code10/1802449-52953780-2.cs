    var p1 = new Person{ Name = "John" };
    AssignAnotherPerson(ref p1);
    void AssignAnotherPerson(ref Person p)
    {
        p = new Person{ Name = "Sue" }; // Here p is an alias for p1.
    }
