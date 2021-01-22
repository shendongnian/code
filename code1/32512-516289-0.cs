    public interface IOrange
    {
        OrangePeel Peel { get; }
    }
    
    public abstract class OrangeBase : IOrange
    {
        protected OrangeBase() {}
        protected abstract OrangePips Seeds { get; }
        public abstract OrangePeel Peel { get; }
    }
    public class NavelOrange : OrangeBase
    {
        public override OrangePeel Peel { get { return new OrangePeel(); } }
        protected override OrangePips Seeds { get { return null; } }
    }
   
    public class ValenciaOrange : OrangeBase
    {
        public override OrangePeel Peel { get { return new OrangePeel(); } }
        protected override OrangePips Seeds { get { return new OrangePips(6); } }
    }
    
