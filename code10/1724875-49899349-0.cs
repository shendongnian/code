    public abstract class SVG
    {
        public abstract string GetSVG(string path);
    }
    public class MyController : SVG
    {
        public override string GetSVG(string path)
        {
             // your implementation
        }
    }
