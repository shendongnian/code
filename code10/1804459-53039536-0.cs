    class Agent
    {
        public Point3d Pos = new Point3d();
        Vector3d Vec = new Vector3d();
        int Alignment;
        double Separation;
        double Cohesion;
        double NeighborRadius;
    
        public Agent(Point3d pos, Vector3d vec, int alignment, double separation, double cohesion, double neighborRadius)
        {
            Pos = pos;
            Vec = vec;
            Alignment = alignment;
            Separation = separation;
            Cohesion = cohesion;
            NeighborRadius = neighborRadius;
        }
    }
----------
    List<Agent> allAgents = new List<Agent>();
    List<Point3d> agentPositions = new List<Point3d>();
    
    // Initialize Agents
    //.
    //.
    //.
    
    
    agentPositions = allAgents.Select(agent => agent.Pos).ToList();
