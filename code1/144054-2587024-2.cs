    class EventRendererRegistry
    {
        public void Add(IEventRenderer renderer)
        {
            mRenderers.Add(renderer);
        }
        
        public void Draw(Event event)
        {
            foreach (var renderer in mRenderers)
            {
                if (renderer.Draw(event)) break;
            }
        }
        
        private readonly List<IEventRenderer> mRenderers = new List<IEventRenderer>();
    }
