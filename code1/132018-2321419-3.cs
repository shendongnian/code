    List<Action> actions = new List<Action>();
    for (int i=0;i<9;i++)
    {
        ClassA  objectA= new ClassA();
        actions.Add(delegate { Console.WriteLine(objectA.GetHashCode()); });        
    }
    foreach(Action action in actions) action();
