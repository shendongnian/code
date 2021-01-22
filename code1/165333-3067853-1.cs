    // assume class Point { public int x, y; }
    // pt is a managed variable, subject to garbage collection.
    Point pt = new Point();
    // Using fixed allows the address of pt members to be
    // taken, and "pins" pt so it isn't relocated.
    fixed ( int* p = &pt.x )
    {
        *p = 1; 
    }
