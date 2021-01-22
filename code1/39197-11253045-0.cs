    public interface IDrawableFactory
    {
        TDrawable GetDrawingObject<TDrawable>(GraphicsDeviceManager graphicsDeviceManager) 
                  where TDrawable: class, IDrawable, new();
    }
    public class DrawableFactory : IDrawableFactory
    {
        public TDrawable GetDrawingObject<TDrawable>(GraphicsDeviceManager graphicsDeviceManager) 
                         where TDrawable : class, IDrawable, new()
        {
            return (TDrawable) Activator
                    .CreateInstance(typeof(TDrawable), 
                                    graphicsDeviceManager);
        }
    }
    public class Draw : IDrawable
    {
     //stub
    }
    public class Update : IDrawable {
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        public Update() { throw new NotImplementedException(); }
        public Update(GraphicsDeviceManager graphicsDeviceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
        }
    }
    public interface IDrawable
    {
        //stub
    }
    public class GraphicsDeviceManager
    {
        //stub
    }
