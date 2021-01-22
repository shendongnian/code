    public Direction GetDirection(Point a, Point , Point c)
    {
        double theta1 = GetAngle(a, b); 
        double theta2 = GetAngle(b, c);
        double delta = NormalizeAngle(theta2 - theta1);
        
        if ( delta == 0 )
            return Direction.Straight;
        else if ( delta == Math.PI )
            return Direction.Backwards;
        else if ( delta < Math.PI )
            return Direction.Left;
        else return Direction.Right;
    }
    private Double GetAngle(Point p1, Point p2)
    {
        Double angleFromXAxis = Math.Atan ((p2.Y - p1.Y ) / (p2.X - p1.X ) ); // where y = m * x + K
        return  p2.X - p1.X < 0 ? m + Math.PI : m ); // The will go to the right Quadrant
    }
    private Double NormalizeAngle(Double angle)
    {
        return angle < 0 ? angle + 2 * Math.PI : angle; //This will make sure angle is [0..2PI]
    }
