    class B : A
    {
        public sealed override void Render()
        {
            // Prepare the object for rendering
            SpecialRender();
            // Do some cleanup
        }
        protected virtual void SpecialRender()
        {
        }
    }
