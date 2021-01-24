    public abstract class TblBase
    {
        public int COID { get; set; }
        //other common properties
    }
    public class TblLine : TblBase
    {
        // no COID here
        // properties
    }
    public class TblDevice : TblBase
    {
        // no COID here
        // properties
    }
