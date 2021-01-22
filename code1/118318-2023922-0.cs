    public interface IWidget
    {
        IList<Widget.LittleThing> LookupThings();
    }
    
    // For definitions used by IWidget
    public class Widget
    {
        public struct LittleThing
        {
            int foo;
            DateTime bar;
        }
    }
