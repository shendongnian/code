        public void RotateMesh(MeshGeometry3D mesh, Vector3D axis, double angle)
        {
            var transform = new RotateTransform3D(); 
            transform.Rotation = new AxisAngleRotation3D(axis, angle);
            for (int i = 0; i < mesh.Positions.Count; ++i) 
                mesh.Positions[i] = transform.Transform(mesh.Positions[i]);
        }
