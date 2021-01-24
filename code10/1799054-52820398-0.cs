    public class AssignCells
        {
            List<List<ParameterInfo>> Cells = new List<List<ParameterInfo>>();
            public AssignCells(Vector3 bottom, Vector3 top, Vector3 right, Vector3 left)
            {
                Type Parm = typeof(AssignCells);
                Type[] VC = new Type[4];
                VC[0] = typeof(Vector3);
                VC[1] = typeof(Vector3);
                VC[2] = typeof(Vector3);
                VC[3] = typeof(Vector3);
                var Constructbase = Parm.GetConstructor(VC);
                if (top.x == bottom.x + 20.0 && right.x == left.x + 50.0)
                {
                    Cells.Add(Constructbase.GetParameters().ToList());
                }
            }
        }
