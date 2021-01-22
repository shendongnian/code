        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            UpdateWireframe();
        }
        void UpdateWireframe()
        {
            GeometryModel3D model = cube.Content as GeometryModel3D;
            canvas.Children.Clear();
            if (model != null && this.IsAncestorOf(cube))
            {
                GeneralTransform3DTo2D transform = cube.TransformToAncestor(this);
                MeshGeometry3D geometry = model.Geometry as MeshGeometry3D;
                for (int i = 0; i < geometry.TriangleIndices.Count;)
                {
                    Polygon p = new Polygon();
                    p.Stroke = Brushes.Blue;
                    p.StrokeThickness = 0.25;
                    p.Points.Add(transform.Transform(geometry.Positions[geometry.TriangleIndices[i++]]));
                    p.Points.Add(transform.Transform(geometry.Positions[geometry.TriangleIndices[i++]]));
                    p.Points.Add(transform.Transform(geometry.Positions[geometry.TriangleIndices[i++]]));
                    canvas.Children.Add(p);
                }
            }
        }
