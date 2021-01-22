    private Vector3 position;
    public Vector3 Position {
        get {return position;}
        set {position = value;}
    }
    public float X {
        get {return position.X;}
        set {position = new Vector3(value, position.Y, position.Z);}
    }
    public float Y {
        get {return position.Y;}
        set {position = new Vector3(position.X, value, position.Z);}
    }
    public float Z {
        get {return position.Z;}
        set {position = new Vector3(position.X, position.Y, value);}
    }
