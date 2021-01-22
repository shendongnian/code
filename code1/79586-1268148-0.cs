    static public void ChangePoints( this PointCollection pc, Vector v ) {
        for (int i = 0; i < pc.Count; i++ ) {
            pc[i] = pc[i] + v;
        }
    }
