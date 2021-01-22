    class MyMesh {
        ...
    
        public Point3D[] ToPoint3D()
        {
            Point3D[] p3D = null;   // or set it to an Empty Point3D array, if necessary
    
            if (mpts.Length > 0)
            {
                p3D = new Point3D[mpts.Length]
    
                for (int x = 0; x < mypts.Length; x++)
                {
                    p3D[x].X = new Point3D(mypts[x].m_i;
                    p3D[x].Y = new Point3D(mypts[x].m_j;
                    p3D[x].Z = new Point3D(mypts[x].m_k;
                }
            }
    
            return p3D;
        }
    
        ...
    }
