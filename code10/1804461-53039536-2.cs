    class Agent
    {
        public Agent()
        {
           Pos = new Point3d();
        }
        public Point3d Pos { get;private set; }
        //.
        //.
        //.
    }
----------
    List<Agent> allAgents = new List<Agent>();
    List<Point3d> agentPositions = new List<Point3d>();
    
    // Initialize Agents
    //.
    //.
    //.
    
    
    agentPositions = allAgents
                .Select(agent => agent.Pos)
                .ToList();
