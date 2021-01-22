        public int MaxZIndex
        {
          get {
            return FloatingWindows.Aggregate(-1, (maxZIndex, window) => {
              int w = Canvas.GetZIndex(window);
              return (w > maxZIndex) ? w : maxZIndex;
            });
          }
        }
        private void SetTopmost(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            Canvas.SetZIndex(element, MaxZIndex + 1);
        }
