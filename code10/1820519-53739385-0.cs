    public interface IDimensions
    {
        int Height {get;set;}
        int Width {get;set;}
        int Depth {get;set;}
        int Weight { get=>0; set{} }
        int Density { get=> Weight==0?0:Height*Width*Depth/Weight ; }
    }
    public class Box:IDimensions
    {
        public int Height{get;set;}
        public int Width{get;set;}
    }
