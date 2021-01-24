    public interface IRenderer
    {
        void Draw(/* Params needed to draw */);
    }
    public interface IOption
    {
        //Some Shared attributes for all Options
        IRenderer Renderer { get; }
    }
