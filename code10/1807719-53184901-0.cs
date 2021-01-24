    Vector3 MinResult(Vector3 u, Vector3 v)
      {
         Vector3 minVec = v;
         if (u.X < v.X)
         {
            minVec.X = u.X;
         }
         if (u.Y < v.Y)
         {
            minVec.Y = u.Y;
         }
         if (u.Z < v.Z)
         {
            minVec.Z = u.Z;
         }
         return minVec;
      }
      Vector3 MaxResult(Vector3 u, Vector3 v)
      {
         Vector3 maxVec = v;
         if (u.X > v.X)
         {
            maxVec.X = u.X;
         }
         if (u.Y > v.Y)
         {
            maxVec.Y = u.Y;
         }
         if (u.Z > v.Z)
         {
            maxVec.Z = u.Z;
         }
         return maxVec;
      }
    private void SetUpVertices()
    {
         vertices = new VertexPositionColor[8];
         //front left bottom corner
         vertices[0] = new VertexPositionColor(new Vector3(0, 0, 0), color);
         //front left upper corner
         vertices[1] = new VertexPositionColor(new Vector3(0, 5, 0), color);
         //front right upper corner
         vertices[2] = new VertexPositionColor(new Vector3(5, 5, 0), color);
         //front lower right corner
         vertices[3] = new VertexPositionColor(new Vector3(5, 0, 0), color);
         //back left lower corner
         vertices[4] = new VertexPositionColor(new Vector3(0, 0, -5), color);
         //back left upper corner
         vertices[5] = new VertexPositionColor(new Vector3(0, 5, -5), color);
         //back right upper corner
         vertices[6] = new VertexPositionColor(new Vector3(5, 5, -5), color);
         //back right lower corner
         vertices[7] = new VertexPositionColor(new Vector3(5, 0, -5), color);
         Vector3 max = vertices[0].Position;
         Vector3 min = vertices[0].Position;
         foreach(VertexPositionColor vc in vertices)
         {
            min = MinResult(min, vc.Position);
            max = MaxResult(max, vc.Position);
         }
         collisionBox = new BoundingBox(min, max);
         vBuffer = new VertexBuffer(gd, typeof(VertexPositionColor), 8, BufferUsage.WriteOnly);
         vBuffer.SetData<VertexPositionColor>(vertices);
      }
