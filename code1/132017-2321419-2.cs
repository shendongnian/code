    List<Action> actions = new List<Action>();
    ClassA objectA;
    for (int i=0;i<9;i++)
    {
        objectA= new ClassA();
        actions.Add(delegate { Console.WriteLine(objectA.GetHashCode()); });        
    }
    foreach(Action action in actions) action();
