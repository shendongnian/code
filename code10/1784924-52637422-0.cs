        //Methods
        public void DrawRectangle(Color c, int stroke, float w, float h, Graphics g, float radius)
        {
            this.width = w;
            this.height = h;
            this.strokeThickness = stroke;
            this.type = ShapeType.rectangle;
            this.radius = radius;
            //Centering the Shape
            PointF points = new PointF();
            //w -= strokeThickness;
            //h -= strokeThickness;
            points.X = (center.X - ((w) / 2f));
            points.Y = (center.Y - ((h) / 2f));
            //Aliasing for smooth graphics when drawing and resizing
            g.InterpolationMode = InterpolationMode.High;
            //Drawing
            RectangleF rect = new RectangleF(points.X, points.Y, w, h);
            GraphicsPath path = this.GetRoundedRect(rect, radius);
            g.DrawPath(new Pen(c, stroke), path);
        }
        public void DrawSquare(Color c, int stroke, float w, float h, Graphics g, float radius)
        {
            this.width = w;
            this.height = h;
            this.strokeThickness = stroke;
            this.type = ShapeType.square;
            this.radius = radius;
            //w -= strokeThickness;
            //h -= strokeThickness;
            //Centering the Shape
            PointF points = new PointF();
            points.X = (center.X - (w / 2));
            points.Y = (center.Y - (h / 2) + DefaultOffset);
            //Aliasing for smooth graphics when drawing and resizing
            g.InterpolationMode = InterpolationMode.High;
            //Drawing
            RectangleF rect = new RectangleF(points.X, points.Y, w, h);
            GraphicsPath path = this.GetRoundedRect(rect, radius);
            g.DrawPath(new Pen(c, stroke), path);
        }
        public void DrawCircle(Color c, int stroke, float w, float h, Graphics g)
        {
            this.width = w;
            this.height = h;
            this.strokeThickness = stroke;
            this.type = ShapeType.circle;
            PointF points = new PointF();
            //Centering the Shape
            points.X = (float)((center.X - (w/ 2)));
            points.Y = (float)((center.Y - (h / 2)));
            //Aliasing for smooth graphics when drawing and resizing
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Drawing
            RectangleF rect = new RectangleF(points.X, points.Y, w, h);
            g.DrawEllipse(new Pen(c, stroke), rect);
        }
        public void DrawEllipse(Color c, int stroke, float w, float h, Graphics g)
        {
            this.width = w;
            this.height = h;
            this.strokeThickness = stroke;
            this.type = ShapeType.ellipse;
            //Centering the Shape
            PointF points = new PointF();
            points.X = (center.X - (w / 2));
            points.Y = (center.Y - (h / 2));
            //Aliasing for smooth graphics when drawing and resizing
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Drawing
            RectangleF rect = new RectangleF(points.X, points.Y, w, h);
            g.DrawEllipse(new Pen(c, stroke), rect);
            
        }
        public void DrawTriangle(Color c, int stroke, float w, Graphics g, float radius)
        {
            this.strokeThickness = stroke;
            this.type = ShapeType.triangle;
            float h = (float)((w * (Math.Sqrt(3))) / 2);
            PointF points = new PointF();
            points.Y = (int)(((center.Y - h) + (h / 3f)) + DefaultOffset);
            points.X = (int)center.X - (w / 2f);
            this.size = new SizeF(w, h);
            this.location = points;
            //Calculation of the triangle points
            RectangleF rect = new RectangleF(this.location, this.size);
            PointF A = new PointF(rect.X, rect.Y + rect.Height);
            PointF B = new PointF(rect.X + (rect.Width / 2f), rect.Y);
            PointF C = new PointF(rect.Right, rect.Y + rect.Height);
            //Drawing
            GraphicsPath path = this.DrawRoundedTriangle(rect, A, B, C, radius);
            g.DrawPath(new Pen(c, stroke), path);
        }
        #endregion
