     Transform3DGroup myTransform3DGroup = new Transform3DGroup();
            RotateTransform3D rotateTransform = new RotateTransform3D()
            {
                Rotation = new AxisAngleRotation3D
                {
                    Angle = 40,
                    Axis = new Vector3D(0, 1, 0)
                }
            };
           
            myTransform3DGroup.Children.Add(rotateTransform);
            ArcModel.Transform = myTransform3DGroup;
            ArcModel.Material = myDiffuseMaterial;
            ArcModel.Geometry = testGeometry;
           
            ArcModel.Visual = arcPath;
            viewport.Children.Add(ArcModel);
