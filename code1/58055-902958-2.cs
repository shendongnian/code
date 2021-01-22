        public class Ball
        {
            private Brush brush;
    
            public float X { get; set; }
            public float Y { get; set; }
            public float DX { get; set; }
            public float DY { get; set; }
            public Color Color { get; set; }
            public float Size { get; set; }
    
            public void Draw(Graphics g)
            {
                if (this.brush == null)
                {
                    this.brush = new SolidBrush(this.Color);
                }
                g.FillEllipse(this.brush, X, Y, Size, Size);
            }
    
            public void MoveRight()
            {
                this.X += DX;
            }
    
            public void MoveLeft()
            {
                this.X -= this.DX;
            }
    
            public void MoveUp()
            {
                this.Y -= this.DY;
            }
    
            public void MoveDown()
            {
                this.Y += this.DY;
            }
        }
