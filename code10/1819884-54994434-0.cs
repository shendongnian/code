        private bool IsCompositionVisualReady(UIElement element)
        {
            var visual = ElementCompositionPreview.GetElementVisual(element);
            if (visual.Size.X == 0 && visual.Size.Y == 0)
            {
                return false;
            }
            return true;
        }
