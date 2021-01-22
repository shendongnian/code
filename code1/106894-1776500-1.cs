        public Form2()
        {
            InitializeComponent();
                       
            EnableDragging(pictureBox1);
            EnableDragging(button1);
            EnableDragging(this);
        }
        private void EnableDragging(Control c)
        {
            // Long way, but strongly typed.
            var downs = from down in Observable.FromEvent<MouseEventHandler, MouseEventArgs>(
                            eh => new MouseEventHandler(eh), 
                            eh => c.MouseDown += eh,  
                            eh => c.MouseDown -= eh)
                        select new { down.EventArgs.X, down.EventArgs.Y };
            // Short way.
            var moves = from move in Observable.FromEvent<MouseEventArgs>(c, "MouseMove")
                        select new { move.EventArgs.X, move.EventArgs.Y };
            var ups = Observable.FromEvent<MouseEventArgs>(c, "MouseUp");
            var drags = from down in downs
                        from move in moves.TakeUntil(ups)
                        select new Point { X = move.X - down.X, Y = move.Y - down.Y };
            
            drags.Subscribe(drag => c.SetBounds(c.Location.X + drag.X, c.Location.Y + drag.Y, 0, 0, BoundsSpecified.Location));
        }  
