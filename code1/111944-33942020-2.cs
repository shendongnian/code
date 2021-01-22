    IHaveAProblemComparer comparer = new IHaveAProblemComparer();
    List<IHaveAProblem> myListOfInterfaces = GetSomeIHaveAProblemObjects();
    myListOfInterfaces.Sort(comparer); // items ordered by Issue
    IHaveAProblem obj1 = new SomeProblemTypeA() { Issue = "Example1" };
    IHaveAProblem obj2 = new SomeProblemTypeB() { Issue = "Example2" };
    bool areEquals = comparer.Equals(obj1, obj2); // False
