    public interface IDrawable
    {
        void Update();
        void Draw();
    }
    public interface IDrawableConstructor<T> where T : IDrawable
    {
        T Construct(GraphicsDeviceManager manager);
    }
    public class Triangle : IDrawable
    {
        public GraphicsDeviceManager Manager { get; set; }
        public void Draw() { ... }
        public void Update() { ... }
        public Triangle(GraphicsDeviceManager manager)
        {
            Manager = manager;
        }
    }
    public TriangleConstructor : IDrawableConstructor<Triangle>
    {
        public Triangle Construct(GraphicsDeviceManager manager)
        {
            return new Triangle(manager);
        } 
    }
