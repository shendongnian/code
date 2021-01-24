    public enum Direction { North, East, South, West }
    public Direction VehicleDirection{ get{ return (Direction)richtung; } } 
    private int richtung = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(++richtung == 4){ richtung == 0; }
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
           if(--richtung < 0){ richtung == 3; }
        }
    }
