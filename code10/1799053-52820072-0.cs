       public class assignCells
        {
            List<List<Vector3>> Cells = new List<List<Vector3>>();
            public assignCells(Vector3 bottom, Vector3 top, Vector3 right, Vector3 left)
            {
                List<Vector3> newListVector3 = new List<Vector3>() { bottom, top, right, left };
                Cells.Add(newListVector3);
            }
        }
