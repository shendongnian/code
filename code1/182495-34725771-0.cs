        public static Rect BoundsRelativeTo(this FrameworkElement child, Visual parent)
        {
            GeneralTransform gt = child.TransformToAncestor(parent);
            return gt.TransformBounds(new Rect(0, 0, child.ActualWidth, child.ActualHeight));
        }
