    public class Drawable : MustInitialize<GraphicsDeviceManager>, IDrawable
    {
        GraphicsDeviceManager _graphicsDeviceManager;
        public Drawable(GraphicsDeviceManager graphicsDeviceManager)
            : base (graphicsDeviceManager)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
        }
        public void Update()
        {
            //use _graphicsDeviceManager here to do whatever
        }
        public void Draw()
        {
            //use _graphicsDeviceManager here to do whatever
        }
    }
