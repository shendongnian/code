    public class CoordSys : Tree<CoordSys>
    {
        CoordSys() : base(null) { }
        CoordSys(CoordSys parent) : base(parent) { }
        public double LocalDistance { get; set; }
        public double GlobalDistance { get { return IsRoot?LocalDistance:Parent.GlobalDistance+LocalDistance; } }
        public static CoordSys NewRootCoordinate() { return new CoordSys(); }
        public CoordSys NewChildCoordinate()
        {
            return new CoordSys(this);
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
        Debug.WriteLine(C.GlobalDistance); // 100+50 = 150
        Debug.WriteLine(D.GlobalDistance); // 100+80 = 180
    }
