    static public void ChangePoints( this PointCollection pc, Vector v ) {
        for (int i = 0; i < pc.Count; i++ ) {
            pc[i] += v;
            // the above works on the indexer because you're doing an operation on the
            // Point rather than on one of the Point's members.
        }
    }
