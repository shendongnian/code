    class Point
    {
    	int x, y, z;
    	public Point(int _x, int _y, int _z)
    	{
    		x = _x; y = _y; z = _z;
    	}
    
    	public bool this[bool[,,] arr]
    	{
    		get { return arr[this.x, this.y, this.z]; }
    		set { arr[this.x, this.y, this.z] = value; }
    	}
    }
