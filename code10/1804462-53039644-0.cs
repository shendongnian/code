    class Agent
    {
        public Point3d Pos {get; private set;}
        public Agent() 
        {
            Pos = new Point3d();
        }
        ....
    }
    foreach (Agent ag in allAgents)
    {
        Console.WriteLine(ag.Pos); //might need to dereference a specific member like x,y, or z
    }
