    private void DrawModel(Model m)
    {
        Matrix[] transforms = new Matrix[m.Bones.Count];
        float aspectRatio = graphics.GraphicsDevice.Viewport.Width / graphics.GraphicsDevice.Viewport.Height;
        m.CopyAbsoluteBoneTransformsTo(transforms);
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f),
            aspectRatio, 1.0f, 10000.0f);
        Matrix view = Matrix.CreateLookAt(new Vector3(0.0f, 50.0f, Zoom), Vector3.Zero, Vector3.Up);
    
        foreach (ModelMesh mesh in m.Meshes)
        {
            foreach (BasicEffect effect in mesh.Effects)
            {
                effect.EnableDefaultLighting();
    
                effect.View = view;
                effect.Projection = projection;
                effect.World = gameWorldRotation * transforms[mesh.ParentBone.Index] * Matrix.CreateTranslation(Position);
            }
            mesh.Draw();
        }
    }
