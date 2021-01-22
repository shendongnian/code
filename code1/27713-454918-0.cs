    public static bool HitTest(Rectangle bounds, float angle, Point location)
            {
                if (angle == 0) return bounds.Contains(location);
    
                using (Matrix matrix = new Matrix())
                {
                    matrix.RotateAt(angle, Center(bounds));
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddRectangle(bounds);
                        path.Transform(matrix);
                        return path.IsVisible(location.X, location.Y);
                    }
                }
            }
