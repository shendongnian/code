        public void DrawLineHorizontal( int X1, int X2, int Y, float HalfHeight, Color Color )
        {
            float width = ( X2 - X1 );
            Matrix m = Matrix.Transformation2D( new Vector2( X1, Y - HalfHeight ), 0f, new Vector2( width, HalfHeight * 2 ),
                Vector2.Zero, 0, Vector2.Zero );
            sprite.Transform = m;
            sprite.Draw( this.tx, Vector3.Zero, new Vector3( X1, Y - HalfHeight, 0 ), Color );
        }
