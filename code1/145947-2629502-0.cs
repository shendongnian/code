    interface ICanvasTool
    {
        void Motion(Point newLocation);
        void Tick();
    }
    abstract class CanvasTool_BaseDraw : ICanvasTool
    {
        protected abstract void PaintAt(Point location);
        public virtual void Motion(Point newLocation)
        {
            // implementation
        }
        public abstract void Tick();
    }
    class CanvasTool_Spray : CanvasTool_BaseDraw
    {
        protected override void PaintAt(Point location)
        {
            // implementation
        }
        public override void Tick()
        {
            // implementation
        }
    }
