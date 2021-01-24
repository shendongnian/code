    public class Branches
    {
        public List<Vector3> Vertices = new List<Vector3>();
        public List<Vector3> Tangents = new List<Vector3>();
        public List<Vector3> Normals = new List<Vector3>();
        public List<PathPoint> PathPoints = new List<PathPoint>();
        public bool visited = false;
     
    }
    private void CreateFinalPath()
    {
        for (int i = 0; i < Branches[h].Vertices.Count; i++)// branch vertices
        {
            for (int n = 0; n < SharedNodes.Count; n++) // shared nodes loop
            {
                if (!Branches[h].visited && SharedNodes[n].Nodes.Point.position == Branches[h].Vertices[i]) // shared node detected , see next branch to take
                {
                    Branches[h].visited = true;
                    h = SharedNodes[n].BranchToFollow; // next branch ID to take
                    CreateFinalPath(); // trigger data storage for the new branch in Final path class
                    break;
                }
            }
            // data storage in finalpath class
            FinalPath.Vertices.Add(Branches[h].Vertices[i]);
            FinalPath.Normals.Add(Branches[h].Normals[i]);
            FinalPath.Tangents.Add(Branches[h].Tangents[i]);
        }
    }
