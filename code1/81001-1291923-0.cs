        public UIElement GetRootVisual()
        {
            UIElement root = AdornedElement;
            if (root != null)
            {
                UIElement parent = VisualTreeHelper.GetParent(root) as UIElement;
                if (parent != null)
                {
                    root = parent;
                }
            }
            return root;
        }
