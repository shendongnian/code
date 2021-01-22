       public FrameworkElement FindIntersectingElement(Rect rectangle, UIElement activeElement)
        {
            FrameworkElement found = null;
            System.Threading.Tasks.Parallel.ForEach((IEnumerable<UIElement>)MainPanel.Children, 
               (child, loopState) =>
            {
                if (child != activeElement)
                {
                    if (GetBounds(child as FrameworkElement, MainPanel).IntersectsWith(rectangle))
                    {
                        found = child as FrameworkElement;
                        loopState.Stop();
                    }
                }
            });
            return found;
        }
