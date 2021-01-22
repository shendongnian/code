    public class CoordSys : Tree<CoordSys>
    {
        CoordSys() : base(null) { }
        CoordSys(CoordSys parent) : base(parent) { }
        public double LocalPosition { get; set; }
        public double GlobalPosition { get { return IsRoot?LocalPosition:Parent.GlobalPosition+LocalPosition; } }
        public static CoordSys NewRootCoordinate() { return new CoordSys(); }
        public CoordSys NewChildCoordinate(double localPos)
        {
            return new CoordSys(this) { LocalPosition = localPos };
        }
    }
    static void Main() 
    {
        // Make a coordinate tree:
        //
        //                  +--[C:50] 
        // [A:0]---[B:100]--+         
        //                  +--[D:80] 
        //
        var A=CoordSys.NewRootCoordinate();
        var B=A.NewChildCoordinate(100);
        var C=B.NewChildCoordinate(50);
        var D=B.NewChildCoordinate(80);
        Debug.WriteLine(C.GlobalPosition); // 100+50 = 150
        Debug.WriteLine(D.GlobalPosition); // 100+80 = 180
    }
