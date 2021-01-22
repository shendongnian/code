    private Vector3 position;
    public Vector3 Position {
        get {return position;}
        set {position = value;} // with @Mehrdad's optimisation
    }
    public float X {
        get {return position.X;}
        set {position.X = value;}
    }
    public float Y {
        get {return position.Y;}
        set {position.Y = value;}
    }
    public float Z {
        get {return position.Z;}
        set {position.Z = value;}
    }
