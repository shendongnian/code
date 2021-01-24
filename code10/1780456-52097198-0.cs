    public class FakeView : IView
    {
        private string RenderedText { get; private set; }
        public event Action Loaded;
        public void Render(string text)
        {
            renderedText = text;
        }
        public void RaiseLoaded() {
            if (Loaded != null) Loaded();
        }
    }
