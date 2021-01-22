        /// <summary>
        /// Takes a 3D point and returns the corresponding 2D point (X,Y) within the viewport.  
        /// Requires the 3DUtils project available at http://www.codeplex.com/Wiki/View.aspx?ProjectName=3DTools
        /// </summary>
        /// <param name="point3D">A point in 3D space</param>
        /// <param name="viewPort">An instance of Viewport3D</param>
        /// <returns>The corresponding 2D point or null if it could not be calculated</returns>
        public Point? Point3DToScreen2D(Point3D point3D, Viewport3D viewPort)
        {
            bool bOK = false;
            // We need a Viewport3DVisual but we only have a Viewport3D.
            Viewport3DVisual vpv =VisualTreeHelper.GetParent(viewPort.Children[0]) as Viewport3DVisual;
            // Get the world to viewport transform matrix
            Matrix3D m = MathUtils.TryWorldToViewportTransform(vpv, out bOK);
            if (bOK)
            {
                // Transform the 3D point to 2D
                Point3D transformedPoint = m.Transform(point3D);
                Point screen2DPoint = new Point(transformedPoint.X, transformedPoint.Y);
                return new Nullable<Point>(screen2DPoint);
            }
            else
            {
                return null; 
            }
        }
