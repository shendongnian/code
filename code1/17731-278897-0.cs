    public int Compare(Person p1, Person p2)
    {
        return PartialComparer.Compare(p1.Age, p2.Age)
            ?? PartialComparer.Compare(p1.Name, p2.Name)
            ?? PartialComparer.Compare(p1.Salary, p2.Salary)
            ?? 0;
    }
